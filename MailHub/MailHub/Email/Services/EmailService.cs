using MailHub.Email.Models;
using MailHub.Email.Models.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
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
    /// <summary>
    /// Represents an service that manages email messages
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly ILogger<EmailService> _logger;
        private readonly ISmtpClientFactory _smptClientFactory;

        /// <summary>
        /// Creates a new instance of the <see cref="EmailService"/> class
        /// </summary>
        /// <param name="emailConfiguration">Used for accessing the SMPT and POP3 information</param>
        /// <param name="logger">Used for logging</param>
        /// <param name="smptClientFactory">Used for creating an instance of the <see cref="SmtpClient"/></param>
        public EmailService(IEmailConfiguration emailConfiguration, ILogger<EmailService> logger, ISmtpClientFactory smptClientFactory)
        {
            _emailConfiguration = emailConfiguration;
            _logger = logger;
            _smptClientFactory = smptClientFactory;
        }

        /// <summary>
        /// Sends an email message
        /// </summary>
        /// <param name="emailMessage">The email message to be sent</param>
        /// <returns>A Task for awaiting</returns>
        public async Task Send(EmailMessage emailMessage)
        {
            if (emailMessage == null)
            {
                throw new ArgumentNullException(nameof(emailMessage), "The email message cannot be null");
            }

            _logger.LogDebug("Attempting to send an email {@emailMessage}", emailMessage);

            var message = CreateMimeMessage(emailMessage);
            var useSSL = true;
            var oAuth2AuthenticationType = "XOAUTH2";
            
            using (var emailClient = _smptClientFactory.Create())
            {
                //emailClient.ServerCertificateValidationCallback = (s, c, ch, ssl) => true; //Need to implement better validation

                await emailClient.ConnectAsync(_emailConfiguration.Server, _emailConfiguration.Port, useSSL);

                emailClient.AuthenticationMechanisms.Remove(oAuth2AuthenticationType);

                await emailClient.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);

                await emailClient.SendAsync(message);

                await emailClient.DisconnectAsync(true);
            }

            _logger.LogDebug("Email successfully sent {@emailMessage}", emailMessage);
        }

        private MimeMessage CreateMimeMessage(EmailMessage emailMessage)
        {
            var message = new MimeMessage()
            {
                Subject = emailMessage.Subject,
                Body = new TextPart(TextFormat.Text)
                {
                    Text = emailMessage.Content
                }
            };

            message.From.Add(new MailboxAddress(""));
            message.To.Add(new MailboxAddress(emailMessage.ToAddress));

            return message;
        }
    }
}
