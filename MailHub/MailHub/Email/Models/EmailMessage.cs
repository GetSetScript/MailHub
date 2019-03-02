using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Email.Models
{
    /// <summary>
    /// Represents the content of an email
    /// </summary>
    public class EmailMessage
    {
        /// <summary>
        /// The email address to send to
        /// </summary>
        public string ToAddress { get; set; }

        /// <summary>
        /// The message content of the email
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The subject of the email
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Creates a new Intance of the <see cref="EmailMessage"/> class
        /// </summary>
        /// <param name="toAddress">The email address to send to</param>
        /// <param name="content">The message content of the email</param>
        /// <param name="subject">The subject of the email</param>
        public EmailMessage(string content, string toAddress, string subject)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("The email message content cannot be null, whitespace or empty", nameof(content));
            }

            if (string.IsNullOrWhiteSpace(toAddress))
            {
                throw new ArgumentException("The email message toAddress cannot be null, whitespace or empty", nameof(toAddress));
            }

            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentException("The email message subject cannot be null, whitespace or empty", nameof(subject));
            }

            ToAddress = toAddress;
            Content = content;
            Subject = subject;
        }
    }
}
