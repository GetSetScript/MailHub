using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Email.Models.Configuration
{
    /// <summary>
    /// Represents the information for the <see cref="SmtpClient"/> server and <see cref="Pop3Client"/> server
    /// </summary>
    public class EmailConfiguration : IEmailConfiguration
    {
        /// <summary>
        /// The target SMTP server domain name
        /// </summary>
        public string SmtpServer { get; set; }

        /// <summary>
        /// the target SMTP port number
        /// </summary>
        public int SmtpPort { get; set; }

        /// <summary>
        /// The username for the target SMTP server
        /// </summary>
        public string SmtpUsername { get; set; }

        /// <summary>
        /// The password for the target SMTP server
        /// </summary>
        public string SmtpPassword { get; set; }

        
        /// <summary>
        /// The target POP3 server domain name
        /// </summary>
        public string PopServer { get; set; }

        /// <summary>
        /// the target POP3 port number
        /// </summary>
        public int PopPort { get; set; }

        /// <summary>
        /// The username for the target POP3 server
        /// </summary>
        public string PopUsername { get; set; }

        /// <summary>
        /// The password for the target POP3 server
        /// </summary>
        public string PopPassword { get; set; }
    }
}
