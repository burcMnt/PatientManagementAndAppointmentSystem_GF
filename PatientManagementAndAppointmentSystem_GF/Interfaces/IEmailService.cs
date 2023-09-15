namespace PatientManagementAndAppointmentSystem_GF.Interfaces
{
    public interface IEmailService
    {
        void SendMail(string userName, string subject, string mailBody);

    }
}
