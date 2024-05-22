using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using DomainLayer.Models.Common;
using Microsoft.Extensions.Options;

namespace ServiceLayer.Common
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSenderSettings _emailSenderSettings;
        public EmailSender(IOptions<EmailSenderSettings> emailSenderSettings)
        {
            _emailSenderSettings = emailSenderSettings.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.Run(() =>
            {
                // Create the mail message
                MailMessage mail = new MailMessage();

                // Set the addresses
                mail.From = new MailAddress(_emailSenderSettings.SmtpServer);
                mail.To.Add(email);

                // Set the content
                mail.Subject = subject;
                mail.Body = htmlMessage;

                // Send the message
                using (SmtpClient smtp = new SmtpClient(_emailSenderSettings.SmtpServer))
                {
                    // IMPORTANT: Your SMTP login email MUST be the same as your FROM address
                    NetworkCredential credentials = new NetworkCredential(_emailSenderSettings.Username, _emailSenderSettings.Password);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credentials;
                    smtp.Port = _emailSenderSettings.Port; // Alternative port number is 8889
                    smtp.EnableSsl = _emailSenderSettings.EnableSsl;
                    smtp.Send(mail);
                }
            });
        }
    }
}
