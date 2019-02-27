namespace MailHub.Email.Models.Configuration
{
    /// <summary>
    /// Represents the Interface for the <see cref="EmailConfiguration"/> class
    /// </summary>
    public interface IEmailConfiguration
    {
        /// <summary>
        /// The password for the target POP3 server
        /// </summary>
        string PopPassword { get; set; }

        /// <summary>
        /// the target POP3 port number
        /// </summary>
        int PopPort { get; set; }

        /// <summary>
        /// The target POP3 server domain name
        /// </summary>
        string PopServer { get; set; }

        /// <summary>
        /// The username for the target POP3 server
        /// </summary>
        string PopUsername { get; set; }

        /// <summary>
        /// The password for the target SMTP server
        /// </summary>
        string SmtpPassword { get; set; }

        /// <summary>
        /// the target SMTP port number
        /// </summary>
        int SmtpPort { get; set; }

        /// <summary>
        /// The target SMTP server domain name
        /// </summary>
        string SmtpServer { get; set; }

        /// <summary>
        /// The username for the target SMTP server
        /// </summary>
        string SmtpUsername { get; set; }
    }
}