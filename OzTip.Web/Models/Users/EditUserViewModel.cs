using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OzTip.Models;

namespace OzTip.Web.Models.Users
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }
        public int? TeamId { get; set; }

        public string UserName { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }

        public List<Team> Teams { get; set; }
}
}