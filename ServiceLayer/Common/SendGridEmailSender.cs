using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Common
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly string _apiKey;

        public SendGridEmailSender(string apiKey)
        {
            _apiKey = apiKey;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("nmisrtocxipremess@gmail.com", "NMIS RTOC R11");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, htmlMessage, htmlMessage);
            return client.SendEmailAsync(msg);
        }
    }
}
