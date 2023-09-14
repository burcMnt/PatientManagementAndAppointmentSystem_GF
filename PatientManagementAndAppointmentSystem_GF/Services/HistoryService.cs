using Microsoft.EntityFrameworkCore;
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
            _dbContext.MedicalHistory.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task Delete(long id, long patientId)
        {

            var history = _dbContext.MedicalHistory.Where(x => x.PatientId == patientId).FirstOrDefault(x => x.Id== id);

            _dbContext.MedicalHistory.Remove(history);
            _dbContext.SaveChanges();
        }

        public async Task<MedicalHistory> GetById(long id)
        {
            return _dbContext.MedicalHistory.Include(x=>x.Patient).FirstOrDefault(x=>x.Id==id);
        }

        public async Task<List<MedicalHistory>> ListAll()
        {
            return _dbContext.MedicalHistory.ToList();

        }

        public async Task Update(MedicalHistory entity)
        {
            _dbContext.MedicalHistory.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
