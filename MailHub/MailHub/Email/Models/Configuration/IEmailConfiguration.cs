namespace MailHub.Email.Models.Configuration
{
    /// <summary>
    /// Represents an Interface for information for internet standared email transmission protocols
    /// </summary>
    public interface IEmailConfiguration
    {
        /// <summary>
        /// The password for the target server
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// the port number of the target server
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// The domain name of the target server
        /// </summary>
        string Server { get; set; }

        /// <summary>
        /// The username for the target server
        /// </summary>
        string Username { get; set; }
    }
}