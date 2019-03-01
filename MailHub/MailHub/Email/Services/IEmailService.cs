using System.Threading.Tasks;
using MailHub.Email.Models;

namespace MailHub.Email.Services
{
    /// <summary>
    /// Represents the interface of an email service that manages email messages
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email message
        /// </summary>
        /// <param name="emailMessage">The email message to be sent</param>
        /// <returns>A Task for awaiting</returns>
        Task Send(EmailMessage emailMessage);
    }
}