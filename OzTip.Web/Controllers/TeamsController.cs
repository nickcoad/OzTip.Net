using OzTip.Interfaces;
using OzTip.Data;
using OzTip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OzTip.Web.Controllers
{
    public class TeamsController : OzTipControllerBase
    {
        private readonly IRepository<Team> _teamRepository;

        public TeamsController(
            ApplicationUserManager userManager,
            IRepository<Team> teamRepository)
            : base(userManager)
        {
            _teamRepository = teamRepository;
        }

        // GET: competitions/details/{id}
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var team = _teamRepository.GetById(id);

            return View(team);
        }
    }
}