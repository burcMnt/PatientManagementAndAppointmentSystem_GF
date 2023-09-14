using Microsoft.EntityFrameworkCore;
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

            _dbContext.Patient.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task Delete(long id)
        {
            var patient = _dbContext.Patient.FirstOrDefault(x => x.Id == id);
            _dbContext.Patient.Remove(patient);
            _dbContext.SaveChanges();
        }

        public async Task<Patient> GetAllPatientAppointment(long patientId)
        {
            var userAppointmentList = _dbContext.Patient.Include(x => x.Appointments).Where(x =>x.Id == patientId).FirstOrDefault();
            return userAppointmentList;
        }

        public async Task<List<MedicalHistory>> GetAllPatientsHistory(long patientId)
        {
             var userHistoryList = _dbContext.Patient.Include(x => x.MedicalHistories).Where(x => x.Id == patientId).FirstOrDefault().MedicalHistories;
            return userHistoryList;
        }

        public async Task<Patient> GetById(long id)
        {

            return _dbContext.Patient.Find(id);

        }

        public async Task<List<Patient>> ListAll()
        {
            return _dbContext.Patient.ToList();

        }

        public async Task Update(Patient entity)
        {
            _dbContext.Patient.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
