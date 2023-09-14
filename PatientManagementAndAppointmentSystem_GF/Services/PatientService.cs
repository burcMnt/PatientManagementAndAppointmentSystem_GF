using PatientManagementAndAppointmentSystem_GF.Data;
using PatientManagementAndAppointmentSystem_GF.Entities;
using PatientManagementAndAppointmentSystem_GF.Interfaces;

namespace PatientManagementAndAppointmentSystem_GF.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Patient> Add(Patient entity)
        {

            _dbContext.Add<Patient>(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task Delete(Patient entity)
        {
            _dbContext.Remove<Patient>(entity);
            _dbContext.SaveChanges();
        }

        public async Task<Patient> GetById(int id)
        {

            return _dbContext.Set<Patient>().Find(id);
                
        }

        public async Task<List<Patient>> ListAll()
        {
            return _dbContext.Set<Patient>().ToList();

        }

        public async Task Update(Patient entity)
        {
            _dbContext.Update<Patient>(entity);
            _dbContext.SaveChanges();
        }
    }
}
