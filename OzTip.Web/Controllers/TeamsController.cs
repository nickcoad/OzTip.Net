using OzTip.Core.Interfaces;
using OzTip.Data;
using OzTip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OzTip.Web.Controllers
{
    public class TeamsController : OzTipControllerBase
    {
        private readonly IRepository<Team> _teamRepository = new RepositoryBase<Team>();

        // GET: competitions/details/{id}
        public ActionResult Details(int id)
        {
            var team = _teamRepository.GetById(id);

            return View(team);
        }
    }
}