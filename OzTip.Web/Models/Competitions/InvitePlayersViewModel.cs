using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OzTip.Models;

namespace OzTip.Web.Models.Competitions
{
    public class InvitePlayersViewModel
    {
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public List<string> EmailAddresses { get; set; }

        public InvitePlayersViewModel()
        {
            EmailAddresses = new List<string>();
        }
    }
}