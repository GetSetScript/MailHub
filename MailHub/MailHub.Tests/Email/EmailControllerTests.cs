using MailHub.Email;
using MailHub.Email.Models;
using MailHub.Email.Models.DTO;
using MailHub.Email.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MailHub.Tests.Email
{
    public class EmailControllerTests
    {
        public class SendContactFormTests : EmailControllerTests
        {
            private readonly Mock<ILogger<EmailController>> _loggerMock = new Mock<ILogger<EmailController>>();
            private readonly Mock<IEmailService> _emailServiceMock = new Mock<IEmailService>();

            private readonly EmailController _controller;
            private readonly ContactFormDto _validContactFormEmail = new ContactFormDto()
            {
                Name = "Bob",
                Email = "bobbert@gmail.com",
                Message = "How are you?"
            };

            public SendContactFormTests()
            {
                _controller = new EmailController(_emailServiceMock.Object, _loggerMock.Object);
            }

            [Fact]
            public async Task Returns204NoContent()
            {
                var result = await _controller.SendContactFormEmail(_validContactFormEmail);

                Assert.IsType<NoContentResult>(result);
            }

            [Fact]
            public async Task Returns500InternalServerError()
            {
                _emailServiceMock.Setup(s => s.Send(It.IsAny<EmailMessage>())).Throws<Exception>();

                var result = await _controller.SendContactFormEmail(_validContactFormEmail);

                var objectResult = Assert.IsType<ObjectResult>(result);
                Assert.Equal(500, objectResult.StatusCode);
                Assert.IsType<string>(objectResult.Value);
            }
        }
    }
}
