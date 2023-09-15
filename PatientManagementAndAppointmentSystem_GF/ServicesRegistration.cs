using PatientManagementAndAppointmentSystem_GF.Interfaces;
using PatientManagementAndAppointmentSystem_GF.Services;

namespace PatientManagementAndAppointmentSystem_GF
{
    public static class ServicesRegistration
    {
        public static void AddAllServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IPatientService, PatientService>();
            serviceCollection.AddScoped<IAppointmentService, AppointmentService>();
            serviceCollection.AddScoped<IHistoryService, HistoryService>();
            serviceCollection.AddScoped<IEmailService, EmailService>();
        }
    }
}
