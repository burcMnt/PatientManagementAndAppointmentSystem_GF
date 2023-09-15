using PatientManagementAndAppointmentSystem_GF.Dtos.Appointment;

namespace PatientManagementAndAppointmentSystem_GF.Interfaces
{
    public interface IEmailService
    {
        void SendMail(string userName, string subject, string mailBody);

        void SendCreatedNotification(long appointmentId);
        Task<List<ReminderDto>> GetAllAppointmentToReminder();


    }
}
