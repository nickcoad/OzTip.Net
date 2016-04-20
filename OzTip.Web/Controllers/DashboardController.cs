using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OzTip.Core.Interfaces;
using OzTip.Models;
using OzTip.Web.Models.Dashboard;

namespace OzTip.Web.Controllers
{
    public class DashboardController : OzTipControllerBase
    {
        private readonly IRepository<Round> _roundRepository;

        public DashboardController(
            IRepository<Round> roundRepository,
            ApplicationUserManager userManager)
            : base(userManager)
        {
            _roundRepository = roundRepository;
        }

        public ActionResult Index()
        {
            var currentRound = _roundRepository.GetWhere(ro => ro.Start <= DateTime.Now && ro.End >= DateTime.Now).FirstOrDefault();
            
            if (currentRound != null)
                return View("round-in-progress");

            var nextRound = _roundRepository.GetWhere(ro => ro.Start >= DateTime.Now).OrderBy(ro => ro.Start).FirstOrDefault();

            if (nextRound == null)
                return View("no-more-rounds");

            var previousRound = _roundRepository.GetWhere(ro => ro.End <= DateTime.Now).OrderByDescending(ro => ro.End).FirstOrDefault();

            var defaultViewModel = new DefaultDashboardViewModel
            {
                PreviousRound = previousRound,
                NextRound = nextRound
            };
            return View("default", defaultViewModel);
        }
    }
}