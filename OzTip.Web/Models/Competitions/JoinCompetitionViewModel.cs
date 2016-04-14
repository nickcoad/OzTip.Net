using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OzTip.Web.Models.Competitions
{
    public class JoinCompetitionViewModel
    {
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public string CompetitionDescription { get; set; }
        public bool CompetitionIsPublic { get; set; }

        [StringLength(50)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}