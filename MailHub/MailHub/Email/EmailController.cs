using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailHub.Email.Models;
using MailHub.Email.Models.DTO;
using MailHub.Email.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace MailHub.Email
{
    /// <summary>
    /// Represents a controller for emails
    /// </summary>
    [ApiController]
    [Route("api/Email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailController> _logger;

        /// <summary>
        /// Creates a new instance of the <see cref="EmailController"/> class
        /// </summary>
        /// <param name="emailService">The email service that will be used to send emails</param>
        /// <param name="logger">Used for logging</param>
        public EmailController(IEmailService emailService, ILogger<EmailController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        /// <summary>
        /// Sends a contact form email
        /// </summary>
        /// <param name="contactFormDto">A data transfer object used to bind incoming data from the body of the request</param>
        /// <returns>An <see cref="IActionResult"/> task</returns>
        [HttpPost("ContactForm")]
        [SwaggerResponse(204, "Returns 204 No Content when the Email has been successfully sent")]
        [SwaggerResponse(500, "Returns a 500 Internal Server Error if the Email failed to send")]
        public async Task<IActionResult> SendContactFormEmail([FromBody] ContactFormDto contactFormDto)
        {
            _logger.LogDebug("Received request to send email: {@email}", contactFormDto);

            var emailSubject = "Contact Form Submission from Get Set Script Portfolio";
            var emailAddress = "getsetscript@gmail.com";
            var emailContent = new StringBuilder();

            emailContent.AppendLine("Name:");
            emailContent.AppendLine(contactFormDto.Name);
            emailContent.AppendLine();
            emailContent.AppendLine("Email Address:");
            emailContent.AppendLine(contactFormDto.Email);
            emailContent.AppendLine();
            emailContent.AppendLine("Message:");
            emailContent.AppendLine(contactFormDto.Message);
            
            try
            {
                var emailMessage = new EmailMessage(emailContent.ToString(), emailAddress, emailSubject);
                await _emailService.Send(emailMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The email service failed to send any email because of an error");
                return StatusCode(500, "There was a problem processing your request");
            }

            return NoContent();
        }
    }
}