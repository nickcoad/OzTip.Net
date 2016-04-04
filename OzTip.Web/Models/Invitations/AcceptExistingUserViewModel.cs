using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OzTip.Models;

namespace OzTip.Web.Models.Invitations
{
    public class AcceptExistingUserViewModel
    {
        public Competition Competition { get; set; }

        public User User { get; set; }

        public string Token { get; set; }
    }
}