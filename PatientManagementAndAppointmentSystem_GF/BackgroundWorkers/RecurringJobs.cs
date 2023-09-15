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
        public static void SendAppoinmentReminderMail(IEmailService emailService )
        {

            EmailOperator EO = new EmailOperator(emailService);
            
            RecurringJob.AddOrUpdate(() => EO.ArrangeAndSendMail()
            , Cron.Daily(08, 30), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));

        }

        


    }
}
