using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Email
{
    /// <summary>
    /// Represents a factory for a <see cref="SmtpClient"/>
    /// </summary>
    public class SmtpClientFactory : ISmtpClientFactory
    {
        /// <summary>
        /// Creates an instance of a <see cref="SmtpClient"/>
        /// </summary>
        /// <returns>A <see cref="SmtpClient"/></returns>
        public SmtpClient Create()
        {
            return new SmtpClient();
        }
    }
}
