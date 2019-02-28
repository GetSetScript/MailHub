using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Email.Models
{
    /// <summary>
    /// Represents the address information for an Email
    /// </summary>
    public class EmailAddress
    {
        /// <summary>
        /// The name of the address holder 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The address of an email
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="EmailAddress"/> class
        /// </summary>
        /// <param name="address">The address of an email</param>
        public EmailAddress(string address)
        {
            Address = address;
        }
    }
}
