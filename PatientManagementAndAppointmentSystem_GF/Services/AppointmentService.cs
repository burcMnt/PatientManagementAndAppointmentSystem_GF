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
            _dbContext.Add<Appointment>(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task Delete(Appointment entity)
        {
            _dbContext.Remove<Appointment>(entity);
            _dbContext.SaveChanges(true);
        }

        public async Task<Appointment> GetById(int id)
        {
            return _dbContext.Set<Appointment>().Find(id);
        }

        public async Task<List<Appointment>> ListAll()
        {
            return _dbContext.Set<Appointment>().ToList();

        }

        public async Task Update(Appointment entity)
        {
            _dbContext.Update<Appointment>(entity);
            _dbContext.SaveChanges();
        }
    }
}
