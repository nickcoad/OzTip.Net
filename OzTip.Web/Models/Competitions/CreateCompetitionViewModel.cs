﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OzTip.Web.Models.Competitions
{
    public class CreateCompetitionViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Private competition")]
        public bool IsPrivate { get; set; }
    }
}