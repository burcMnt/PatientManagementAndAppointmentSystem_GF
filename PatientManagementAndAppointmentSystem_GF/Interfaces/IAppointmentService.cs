using PatientManagementAndAppointmentSystem_GF.Dtos.Appointment;
using PatientManagementAndAppointmentSystem_GF.Entities;

namespace PatientManagementAndAppointmentSystem_GF.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> GetById(long id);
        Task<List<Appointment>> ListAll();
        Task<Appointment> Add(Appointment entity);
        Task Update(Appointment entity);
        Task Delete(long id);

        Task<List<ReminderDto>> GetAllAppointmentToReminder();

        
    }
}
