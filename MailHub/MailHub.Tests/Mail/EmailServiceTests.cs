using MailHub.Email.Models;
using MailHub.Email.Models.Configuration;
using MailHub.Email.Services;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MailHub.Tests.Mail
{
    class EmailServiceTests
    {
        public class SendAsyncTests: EmailServiceTests
        {
            private readonly Mock<ILogger<EmailService>> _loggerMock = new Mock<ILogger<EmailService>>();

            private readonly IEmailService _emailService;
            private readonly IEmailConfiguration _emailConfiguration;
            private readonly EmailMessage _validEmail = new EmailMessage()
            {
                FromAddresses = new List<EmailAddress>()
                    {
                        new EmailAddress()
                        {
                            Name = "Bob",
                            Address = "bobbert@gmail.com"
                        }
                    },
                Content = "Hello Fred",
            };

            
            public SendAsyncTests()
            {
                _emailService = new EmailService(_emailConfiguration, _loggerMock.Object);
            }

            [Fact]
            public async Task SentEmail()
            {
                //arrange

                //act
                await _emailService.Send(_validEmail);

                //assert
            }
        }        
    }
}
