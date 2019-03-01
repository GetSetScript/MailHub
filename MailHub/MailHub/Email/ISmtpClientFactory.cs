using MailKit.Net.Smtp;

namespace MailHub.Email
{
    /// <summary>
    /// Represents an interface for a SMTP client factory
    /// </summary>
    public interface ISmtpClientFactory
    {
        /// <summary>
        /// Creates an instance of a <see cref="SmtpClient"/>
        /// </summary>
        /// <returns>A <see cref="SmtpClient"/> instance</returns>
        SmtpClient Create();
    }
}