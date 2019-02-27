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
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        /// <summary>
        /// The address of an email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Address { get; set; }
    }
}
