using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OzTip.Core.Interfaces;
using OzTip.Models;
using OzTip.Web.Models.Search;

namespace OzTip.Web.Controllers
{
    public class SearchController : OzTipControllerBase
    {
        private readonly IRepository<Competition> _competitionRepository;

        public SearchController(
            ApplicationUserManager userManager,
            IRepository<Competition> competitionRepository)
            : base(userManager)
        {
            _competitionRepository = competitionRepository;
        }

        public ActionResult Index(string query)
        {
            var competitions = _competitionRepository.GetWhere(c => c.Name.Contains(query)).ToList();

            var searchResultsViewModel = new SearchResultsViewModel
            {
                Competitions = competitions,
                SearchString = query
            };

            return View(searchResultsViewModel);
        }
    }
}