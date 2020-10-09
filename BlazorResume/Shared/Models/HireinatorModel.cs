using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorResume.Shared.Models
{
    public class HireinatorModel
    {
        public int Id { get; set; }

        [Required]
        public double MaxSalary { get; set; }

        [Required]
        public double MinSalary { get; set; }

        [Required]
        public double GrayAreaSalary { get; set; }

        [Required]
        public double TargetSalary { get; set; }

        public bool ShowHireinator { get; set; }
    }
}
