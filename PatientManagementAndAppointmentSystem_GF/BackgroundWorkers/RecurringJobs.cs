using Hangfire;
using PatientManagementAndAppointmentSystem_GF.Interfaces;
using System;
using System.Net.Mail;
using System.Runtime.Versioning;

namespace PatientManagementAndAppointmentSystem_GF.BackgroundWorkers
{
    public static class RecurringJobs
    {
        [Obsolete]
        public static void SendAppoinmentReminderMail(IEmailService emailService, IAppointmentService appointmentService)
        {

            EmailOperator EO = new EmailOperator(emailService,appointmentService);
            //ArrangeAndSendMail(emailService, appointmentService);

            //RecurringJob.RemoveIfExists(nameof(ArrangeAndSendMail));


            //RecurringJob.AddOrUpdate<IWeatherReport>(nameof(weather.ReportWeather), x =>
            //      x.ReportWeather(), Cron.Daily(16, 15), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time")); //16:15


            //RecurringJob.AddOrUpdate(() => ArrangeAndSendMail(emailService, appointmentService)
            //, Cron.Daily(02, 52), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));


            RecurringJob.AddOrUpdate(() => EO.ArrangeAndSendMail()
            , Cron.Daily(02, 52), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));


            //RecurringJob.AddOrUpdate<IWeatherReport>(nameof(weather.ReportWeather2), x =>
            //      x.ReportWeather2(), Cron.MinuteInterval(2), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));//2 dakkada bir


            //RecurringJob.AddOrUpdate<IWeatherReport>(nameof(weather.ReportWeather2) + "copy", x =>
            //      x.ReportWeather2(), Cron.Daily(17, 02), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));//17:15
        }

        //public static void ArrangeAndSendMail(IEmailService emailService, IAppointmentService appointmentService)
        //{

        //    var appointmentlist = appointmentService.GetAllAppointmentToReminder();
        //    foreach (var item in appointmentlist.Result)
        //    {

        //        emailService.SendMail(item.UserName,item.Subject,item.MailBody);
        //    }
        //}


    }
}
