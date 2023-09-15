using PatientManagementAndAppointmentSystem_GF.Interfaces;
using System.Net.Mail;
using System.Net;
using System;

namespace PatientManagementAndAppointmentSystem_GF.Services
{
    public class EmailService : IEmailService
    {
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
