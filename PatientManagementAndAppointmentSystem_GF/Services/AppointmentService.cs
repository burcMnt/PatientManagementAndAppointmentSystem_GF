using Microsoft.EntityFrameworkCore;
using PatientManagementAndAppointmentSystem_GF.Data;
using PatientManagementAndAppointmentSystem_GF.Dtos.Appointment;
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
            var appointmentRecord =  _dbContext.Appointment.Add(entity);
            _dbContext.SaveChanges();

            return appointmentRecord.Entity;
        }

        public async Task Delete(long id)
        {
            var appointment = _dbContext.Appointment.FirstOrDefault(x => x.Id == id);
            _dbContext.Appointment.Remove(appointment);
            _dbContext.SaveChanges(true);
        }

        public async Task<Appointment> GetById(long id)
        {
            return await _dbContext.Appointment.Include(x => x.Patient.MedicalHistories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Appointment>> ListAll()
        {
            return _dbContext.Appointment.Include(x => x.Patient).ToList();

        }

        public async Task Update(Appointment entity)
        {
            _dbContext.Appointment.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task<List<ReminderDto>> GetAllAppointmentToReminder()
        {

            var appointmentList = _dbContext.Appointment.Include(x => x.Patient).Where(x => x.AppointmentTime.Date == DateTime.Now.Date.AddDays(1)).ToList();

            List<ReminderDto> result = new List<ReminderDto>();

            foreach (var item in appointmentList)
            {
                var fullname = item.Patient.Name + " " + item.Patient.Surname;
                ReminderDto reminderMailDto = new ReminderDto()
                {

                    UserName = item.Patient.Email,
                    Subject = "Randevu Hatırlatma",
                    MailBody = string.Format("<p>Merhaba Sayın {0}, </p>" +
                    "<p>{1} konumunda bulunan hastanemizde {2} tarih ve saatinde randevunuz bulunmaktadır.</p>" +
                    "<p> Sağlıklı günler dileriz. </p>", fullname, item.Location, item.AppointmentTime.ToString())
                };


                result.Add(reminderMailDto);
            }

            return result;

        }


    }

}

