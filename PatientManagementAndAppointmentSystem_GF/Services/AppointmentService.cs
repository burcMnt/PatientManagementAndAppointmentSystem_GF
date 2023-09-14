using Microsoft.EntityFrameworkCore;
using PatientManagementAndAppointmentSystem_GF.Data;
using PatientManagementAndAppointmentSystem_GF.Entities;
using PatientManagementAndAppointmentSystem_GF.Interfaces;

namespace PatientManagementAndAppointmentSystem_GF.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _dbContext;

        public AppointmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Appointment> Add(Appointment entity)
        {
            _dbContext.Appointment.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task Delete(long id)
        {
            var appointment = _dbContext.Appointment.FirstOrDefault(x => x.Id == id);
            _dbContext.Appointment.Remove(appointment);
            _dbContext.SaveChanges(true);
        }

        public async Task<Appointment> GetById(long id)
        {
            return _dbContext.Appointment.Find(id);
        }

        public async Task<List<Appointment>> ListAll()
        {
            return _dbContext.Appointment.Include(x=>x.Patient).ToList();

        }

        public async Task Update(Appointment entity)
        {
            _dbContext.Appointment.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
