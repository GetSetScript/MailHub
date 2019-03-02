using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Email.Models.Configuration
{
    /// <summary>
    /// Represents information for internet standared email transmission protocols
    /// </summary>
    public class EmailConfiguration : IEmailConfiguration
    {
        /// <summary>
        /// The domain name of the target server
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// the port number of the target server
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The username for the target server
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password for the target server
        /// </summary>
        public string Password { get; set; }
    }
}
