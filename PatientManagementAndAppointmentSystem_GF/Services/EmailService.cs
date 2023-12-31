﻿using PatientManagementAndAppointmentSystem_GF.Interfaces;
using System.Net.Mail;
using System.Net;
using System;
using Microsoft.EntityFrameworkCore;
using PatientManagementAndAppointmentSystem_GF.Data;
using PatientManagementAndAppointmentSystem_GF.Dtos.Appointment;

namespace PatientManagementAndAppointmentSystem_GF.Services
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmailService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SendCreatedNotification(long appointmentId)
        {
            var appointment = _dbContext.Appointment.Include(x => x.Patient).FirstOrDefault(x => x.Id == appointmentId);
            if (appointment.Id > 0)
            {
                string fullname = appointment.Patient.Name + " " + appointment.Patient.Surname;
                string userName = appointment.Patient.Email.ToString();
                string subject = "Randevu Bilgilendirme Mesajı";
                string mailBody = string.Format("<p>Merhaba Sayın {0}, </p>" +
                        "<p>{1} konumunda bulunan hastanemizde {2} tarih ve saatinde yeni randevunuz oluşturulmuştur.</p>" +
                        "<p>Lütfen belirtilen zamanda muayene için hazır olunuz.</p>" +
                        "<p> Sağlıklı günler dileriz. </p>", fullname, appointment.Location, appointment.AppointmentTime.ToString());


                SendMail(userName, subject, mailBody);
            }

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
                    Subject = "Randevu Hatırlatma Mesajı",
                    MailBody = string.Format("<p>Merhaba Sayın {0}, </p>" +
                    "<p>{1} konumunda bulunan hastanemizde {2} tarih ve saatinde randevunuz bulunmaktadır.</p>" +
                    "<p>Lütfen belirtilen zamanda muayene için hazır olunuz.</p>" +
                    "<p> Sağlıklı günler dileriz. </p>", fullname, item.Location, item.AppointmentTime.ToString())
                };


                result.Add(reminderMailDto);
            }

            return result;

        }

        public void SendMail(string userName, string subject, string mailBody)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.UseDefaultCredentials = false;

                mail.From = new MailAddress("lightbiringer@gmail.com");
                mail.To.Add(userName);

                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = mailBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential
                        ("lightbiringer@gmail.com", "merb apxq ofmm fijt");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }





    }
}
