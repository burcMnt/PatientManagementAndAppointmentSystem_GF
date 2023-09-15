using PatientManagementAndAppointmentSystem_GF.Interfaces;

namespace PatientManagementAndAppointmentSystem_GF.BackgroundWorkers
{
    public class EmailOperator
    {

        private readonly IEmailService _emailService;

        public EmailOperator(IEmailService emailService)
        {
            _emailService = emailService;
        }


        public void ArrangeAndSendMail()
        {

            var appointmentlist = _emailService.GetAllAppointmentToReminder();
            foreach (var item in appointmentlist.Result)
            {

                _emailService.SendMail(item.UserName, item.Subject, item.MailBody);
            }
        }


    }
}
