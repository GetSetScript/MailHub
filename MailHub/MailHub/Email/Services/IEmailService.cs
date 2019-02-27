using System.Threading.Tasks;
using MailHub.Email.Models;

namespace MailHub.Email.Services
{
    public interface IEmailService
    {
        Task Send(EmailMessage emailMessage);
    }
}