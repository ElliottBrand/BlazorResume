using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorResume.Shared.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Your name is required.")]
        [MaxLength(100)]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "Your email address is required.")]
        [EmailAddress]
        public string SenderEmail { get; set; }

        [Phone]
        public string SenderPhone { get; set; }

        [Required(ErrorMessage = "You must enter a message first.")]
        [MaxLength(2000)]
        public string SenderMessage { get; set; }

        public string ReCaptcha { get; set; }

        // Might want to build this in at some point
        // public string SenderIP { get; set; }
    }
}
