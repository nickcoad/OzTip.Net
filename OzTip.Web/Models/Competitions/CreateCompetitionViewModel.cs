using System;
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

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Make this competition public?")]
        public bool IsPublic { get; set; }
    }
}