using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorResume.Shared.Models
{
    public class JobModel
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Details { get; set; }
    }
}
