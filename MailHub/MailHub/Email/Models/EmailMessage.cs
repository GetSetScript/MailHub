using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Email.Models
{
    /// <summary>
    /// Represents the information for the content of an email
    /// </summary>
    public class EmailMessage
    {
        /// <summary>
        /// The <see cref="EmailAddress"/> to send the email to
        /// </summary>
        public List<EmailAddress> ToAddresses { get; set; } = new List<EmailAddress>();

        /// <summary>
        /// The <see cref="EmailAddress"/> that the email is being sent from
        /// </summary>
        public List<EmailAddress> FromAddresses { get; set; } = new List<EmailAddress>();

        /// <summary>
        /// The subject of the email
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The message content of the email
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Creates a new Intance of the <see cref="EmailMessage"/> class
        /// </summary>
        /// <param name="toAddresses"></param>
        /// <param name="fromAddresses"></param>
        /// <param name="content"></param>
        public EmailMessage(string content)
        {
            Content = content;
        }
    }
}
