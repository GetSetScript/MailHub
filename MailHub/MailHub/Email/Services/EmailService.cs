using MailHub.Email.Models;
using MailHub.Email.Models.Configuration;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Email.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IEmailConfiguration emailConfiguration, ILogger<EmailService> logger)
        {
            _emailConfiguration = emailConfiguration;
            _logger = logger;
        }

        public async Task Send(EmailMessage emailMessage)
        {
            if (emailMessage == null)
            {
                throw new ArgumentNullException("The EmailMessage class cannot be null");
            }
            
            if (string.IsNullOrWhiteSpace(emailMessage.Content))
            {
                throw new ArgumentException("The EmailMessage property Content cannon be null, whitespace or empty");
            }

            var message = CreateMimeMessage(emailMessage);
        }

        private MimeMessage CreateMimeMessage(EmailMessage emailMessage)
        {
            var message = new MimeMessage();

            message.To.AddRange(emailMessage.ToAddresses.Select(m => new MailboxAddress(m.Name, m.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(m => new MailboxAddress(m.Name, m.Address)));

            message.Subject = emailMessage.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            return message;
        }
    }
}
