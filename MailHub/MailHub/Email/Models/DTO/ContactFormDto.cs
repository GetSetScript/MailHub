using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Email.Models.DTO
{
    /// <summary>
    /// Represents contact form information
    /// </summary>
    public class ContactFormDto
    {
        /// <summary>
        /// The name field from the contact form
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address from the contact form
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The message from the contact form
        /// </summary>
        public string Message { get; set; }
    }
}
