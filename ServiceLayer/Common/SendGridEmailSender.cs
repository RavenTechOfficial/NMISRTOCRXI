using DomainLayer.Models.Common;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace ServiceLayer.Common
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public SendGridEmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var from = new EmailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName);
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            return client.SendEmailAsync(msg);
        }
    }
}
