using PatientManagementAndAppointmentSystem_GF.Data;
using PatientManagementAndAppointmentSystem_GF.Entities;
using PatientManagementAndAppointmentSystem_GF.Interfaces;

namespace PatientManagementAndAppointmentSystem_GF.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public HistoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MedicalHistory> Add(MedicalHistory entity)
        {
            _dbContext.Add<MedicalHistory>(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task Delete(MedicalHistory entity)
        {
            _dbContext.Remove<MedicalHistory>(entity);
            _dbContext.SaveChanges();
        }

        public async Task<MedicalHistory> GetById(int id)
        {
            return _dbContext.Set<MedicalHistory>().Find(id);
        }

        public async Task<List<MedicalHistory>> ListAll()
        {
            return _dbContext.Set<MedicalHistory>().ToList();

        }

        public async Task Update(MedicalHistory entity)
        {
            _dbContext.Update<MedicalHistory>(entity);
            _dbContext.SaveChanges();
        }
    }
}
