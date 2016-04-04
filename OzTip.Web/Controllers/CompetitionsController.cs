using OzTip.Core.Interfaces;
using OzTip.Data;
using OzTip.Models;
using OzTip.Web.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OzTip.Web.Models;

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
            if (competition == null)
                return HttpNotFound();

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
            
            AddToastNotification("success", string.Format("You have successfully created a new competition with the name `{0}`.", viewModel.Name));

            return RedirectToAction("index");
        }

        // GET: competitions/manage-settings/{id}
        [HttpGet]
        [ActionName("manage-settings")]
        public ActionResult ManageSettings(int id)
        {
            var competition = _competitionRepository.GetById(id);
            if (competition == null)
                return HttpNotFound();

            return View(competition);
        }

        // GET: competitions/invite-players/{id}
        [HttpGet]
        [ActionName("invite-players")]
        public ActionResult InvitePlayers(int id)
        {
            var competition = _competitionRepository.GetById(id);
            if (competition == null)
                return HttpNotFound();

            var viewModel = new InvitePlayersViewModel
            {
                CompetitionId = id,
                Competition = competition
            };

            return View(viewModel);
        }
        
        // POST: competitions/invite-players/{id}
        [HttpPost]
        [ActionName("invite-players")]
        public ActionResult InvitePlayers(InvitePlayersViewModel viewModel)
        {
            var competition = _competitionRepository.GetById(viewModel.CompetitionId);
            if (competition == null)
                return HttpNotFound();

            if (!ModelState.IsValid)
            {
                viewModel.Competition = competition;
                return View(viewModel);
            }

            foreach (var emailAddress in viewModel.EmailAddresses)
            {
                var invitation = new Invitation
                {
                    CompetitionId = viewModel.CompetitionId,
                    Email = emailAddress,
                    Token = Guid.NewGuid().ToString()
                };

                var invitationRepository = new RepositoryBase<Invitation>();
                invitationRepository.Create(invitation);
            }
            
            AddToastNotification("success", "Player invitations have been sent!");

            return RedirectToAction("details", new { id = viewModel.CompetitionId });
        }

        // GET: competitions/place-tips/{id}
        [HttpGet]
        [ActionName("place-tips")]
        public ActionResult PlaceTips(int id)
        {
            var competition = _competitionRepository.GetById(id);
            if (competition == null)
                return HttpNotFound();

            return View(competition);
        }
    }
}