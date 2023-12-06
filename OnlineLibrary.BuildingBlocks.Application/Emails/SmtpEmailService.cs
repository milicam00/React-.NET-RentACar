using System.Net;
using System.Net.Mail;

namespace OnlineRentCar.BuildingBlocks.Application.Emails
{
    public class SmtpEmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
       
        public SmtpEmailService(string smtpServer,int smtpPort,bool enableSsl,string smtpUsername,string smtpPassword)
        {
            _smtpClient = new SmtpClient(smtpServer)
            {
                Port = smtpPort,
                EnableSsl = enableSsl,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword)
            };

        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {

            var mailAddress = "milicaaa0000@outlook.com";
            
            var mailMessage = new MailMessage
            {
                From = new MailAddress(mailAddress),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            mailMessage.To.Add(to);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
