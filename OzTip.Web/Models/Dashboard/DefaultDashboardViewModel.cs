using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OzTip.Models;

namespace OzTip.Web.Models.Dashboard
{
    public class DefaultDashboardViewModel
    {
        public Round PreviousRound { get; set; }
        public Round NextRound { get; set; }
    }
}