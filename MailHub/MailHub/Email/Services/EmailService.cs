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
            throw new NotImplementedException();
        }

        private MimeMessage CreateEmailMessage(EmailMessage emailMessage)
        {
            if (emailMessage == null)
            {
                throw new ArgumentNullException("The EmailMessage class cannot be null");
            }

            if (!emailMessage.FromAddresses.Any())
            {
                throw new ArgumentException("The EmailMessage class must contain at least one FromAddresses address");
            }

            if (string.IsNullOrWhiteSpace(emailMessage.FromAddresses[0].Name))
            {
                throw new ArgumentException("The EmailAddress property Name cannot be null, whitespace or empty");
            }

            if (string.IsNullOrWhiteSpace(emailMessage.FromAddresses[0].Address))
            {
                throw new ArgumentException("The EmailAddress property Address cannot be null, whitespace or empty");
            }

            if (string.IsNullOrWhiteSpace(emailMessage.Content))
            {
                throw new ArgumentException("The EmailMessage property Content cannon be null, whitespace or empty");
            }

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
