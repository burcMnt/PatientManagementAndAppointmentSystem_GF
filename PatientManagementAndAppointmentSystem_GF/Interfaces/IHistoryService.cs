using PatientManagementAndAppointmentSystem_GF.Entities;

namespace PatientManagementAndAppointmentSystem_GF.Interfaces
{
    public interface IHistoryService
    {
        Task<MedicalHistory> GetById(int id);
        Task<List<MedicalHistory>> ListAll();
        Task<MedicalHistory> Add(MedicalHistory entity);
        Task Update(MedicalHistory entity);
        Task Delete(MedicalHistory entity);
    }
}
