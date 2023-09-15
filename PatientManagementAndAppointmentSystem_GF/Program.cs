using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PatientManagementAndAppointmentSystem_GF;
using PatientManagementAndAppointmentSystem_GF.Data;
using Newtonsoft.Json.Serialization;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.OpenApi.Models;
using PatientManagementAndAppointmentSystem_GF.Interfaces;
using PatientManagementAndAppointmentSystem_GF.BackgroundWorkers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

//Db context connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDbContext"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


//Hangfire Configuration
builder.Services.AddHangfire(x => x.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
.UseSimpleAssemblyNameTypeSerializer()
.UseDefaultTypeSerializer()
.UseMemoryStorage());

builder.Services.AddHangfireServer();

//Extention class for Interface and services
builder.Services.AddAllServices();

//AutoMapper DI
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//JSon Serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



builder.Services.AddSwaggerGen(c=>            
    {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HealthCareSystemAPI",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint
        ("/swagger/v1/swagger.json", "HealthCareSystemAPI"));
}

app.UseHangfireDashboard("/hf-dashboard");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var serviceProvider = builder.Services.BuildServiceProvider();
var _emailService = serviceProvider.GetService<IEmailService>();

RecurringJobs.SendAppoinmentReminderMail(_emailService);


app.Run();

