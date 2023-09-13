using PatientManagementAndAppointmentSystem_GF.Entities;

namespace PatientManagementAndAppointmentSystem_GF.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> GetById(int id);
        Task<List<Patient>> ListAll();
        Task<Patient> Add(Patient entity);
        Task Update(Patient entity);
        Task Delete(Patient entity);
    }
}
