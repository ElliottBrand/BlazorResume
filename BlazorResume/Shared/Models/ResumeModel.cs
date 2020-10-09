using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorResume.Shared.Models
{
    public class ResumeModel
    {
        public int Id { get; set; }

        [Required]
        public string PageTitle { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public string Overview { get; set; }

        public string ResumeImage { get; set; }

        [NotMapped]
        public List<JobModel> Jobs { get; set; }
    }
}
