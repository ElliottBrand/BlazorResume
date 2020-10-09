﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorResume.Shared.Models
{
    public class AboutModel
    {
        public int Id { get; set; }

        public string PageTitle { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }
    }
}
