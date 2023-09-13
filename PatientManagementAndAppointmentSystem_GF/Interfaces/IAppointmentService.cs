using PatientManagementAndAppointmentSystem_GF.Entities;

namespace PatientManagementAndAppointmentSystem_GF.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> GetById(int id);
        Task<List<Appointment>> ListAll();
        Task<Appointment> Add(Appointment entity);
        Task Update(Appointment entity);
        Task Delete(Appointment entity);
    }
}
