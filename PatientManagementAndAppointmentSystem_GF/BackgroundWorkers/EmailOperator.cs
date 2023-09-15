using PatientManagementAndAppointmentSystem_GF.Interfaces;

namespace PatientManagementAndAppointmentSystem_GF.BackgroundWorkers
{
    public class EmailOperator
    {

        private readonly IEmailService _emailService;
        private readonly IAppointmentService _appointmentService;

        public EmailOperator(IEmailService emailService, IAppointmentService appointmentService)
        {
            _emailService = emailService;
            _appointmentService = appointmentService;
        }


        public void ArrangeAndSendMail()
        {

            var appointmentlist = _appointmentService.GetAllAppointmentToReminder();
            foreach (var item in appointmentlist.Result)
            {

                _emailService.SendMail(item.UserName, item.Subject, item.MailBody);
            }
        }


    }
}
