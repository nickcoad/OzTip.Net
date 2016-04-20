using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OzTip.Web.Models.Competitions
{
    public class LeaveCompetitionViewModel
    {
        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }

        [Display(Name = "Remove me from this competition")]
        public bool ConfirmIsTicked { get; set; }
    }
}