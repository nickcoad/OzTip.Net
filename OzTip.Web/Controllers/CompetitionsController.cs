using OzTip.Core.Interfaces;
using OzTip.Data;
using OzTip.Models;
using OzTip.Web.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OzTip.Web.Controllers
{
    public class CompetitionsController : OzTipControllerBase
    {
        private readonly IRepository<Competition> _competitionRepository = new RepositoryBase<Competition>();

        // GET: competitions
        [HttpGet]
        public ActionResult Index()
        {
            var competitions = _competitionRepository.Get();
            return View(competitions);
        }

        // GET: competitions/details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var competition = _competitionRepository.GetById(id);
            return View(competition);
        }

        // GET: competitions/create
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CreateCompetitionViewModel();
            return View(viewModel);
        }

        // POST: competitions/create
        [HttpPost]
        public ActionResult Create(CreateCompetitionViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var newCompetition = new Competition
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                UserId = 1,
                SeasonId = 1,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            _competitionRepository.Create(newCompetition);

            return Success(string.Format("You have successfully created a new competition with the name `{0}`.", viewModel.Name));
        }
    }
}