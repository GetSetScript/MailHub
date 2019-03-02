using MailHub.Email;
using MailHub.Email.Models;
using MailHub.Email.Models.Configuration;
using MailHub.Email.Services;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MailHub.Tests.Email
{
    public class EmailServiceTests
    {
        public class SendAsyncTests : EmailServiceTests
        {
            private readonly Mock<ILogger<EmailService>> _loggerMock = new Mock<ILogger<EmailService>>();
            private readonly Mock<IEmailConfiguration> _emailConfigurationMock = new Mock<IEmailConfiguration>();
            private readonly Mock<ISmtpClientFactory> _smtpClientFactoryMock = new Mock<ISmtpClientFactory>();
            private readonly Mock<SmtpClient> _smtpClientMock = new Mock<SmtpClient>();

            private readonly IEmailService _emailService;
            private readonly EmailMessage _validEmail = new EmailMessage("Hello Fred, how are you", "fred@mail.com", "Greetings");

            public SendAsyncTests()
            {
                _smtpClientMock.SetupGet(c => c.AuthenticationMechanisms).Returns(new HashSet<string>());

                _smtpClientFactoryMock.Setup(s => s.Create()).Returns(_smtpClientMock.Object);

                _emailConfigurationMock.SetupGet(c => c.Server).Returns("smtp.mail.com");
                _emailConfigurationMock.SetupGet(c => c.Port).Returns(465);
                _emailConfigurationMock.SetupGet(c => c.Username).Returns("test@email.com");
                _emailConfigurationMock.SetupGet(c => c.Password).Returns("password123");

                _emailService = new EmailService(_emailConfigurationMock.Object, _loggerMock.Object, _smtpClientFactoryMock.Object);
            }

            [Fact]
            public async Task EmailSent()
            {
                await _emailService.Send(_validEmail);

                _smtpClientMock.Verify(s => s.SendAsync(It.IsAny<MimeMessage>(), It.IsAny<CancellationToken>(), It.IsAny<ITransferProgress>()), Times.Once);
            }

            [Fact]
            public async Task ThrowsException_NullEmailMessage()
            {
                var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () => await _emailService.Send(null));
                Assert.Equal("emailmessage", exception.ParamName.ToLower());
            }
        }
    }
}
