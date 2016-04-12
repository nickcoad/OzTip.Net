using OzTip.Core.Interfaces;
using OzTip.Data;
using OzTip.Models;
using OzTip.Web.Models.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OzTip.Web.Helpers;
using OzTip.Web.Models;

namespace OzTip.Web.Controllers
{
    public class CompetitionsController : OzTipControllerBase
    {
        private readonly IRepository<Competition> _competitionRepository;
        private readonly IRepository<Invitation> _invitationRepository;

        public CompetitionsController(
            IRepository<Competition> competitionRepository,
            IRepository<Invitation> invitationRepository,
            ApplicationUserManager userManager)
            : base(userManager)
        {
            _competitionRepository = competitionRepository;
            _invitationRepository = invitationRepository;
        }

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
            newCompetition.Users.Add(LoggedInUser);
            _competitionRepository.SaveChanges();
            
            AddToastNotification("success", string.Format("You have successfully created a new competition with the name `{0}`.", viewModel.Name));

            return RedirectToAction("details", new { id = newCompetition.Id });
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
            viewModel.Competition = _competitionRepository.GetById(viewModel.CompetitionId);
            if (viewModel.Competition == null)
                return HttpNotFound();

            viewModel.EmailAddresses.RemoveAll(string.IsNullOrEmpty);

            if (!ModelState.IsValid || !viewModel.EmailAddresses.Any())
            {
                return View(viewModel);
            }

            var loopIndex = 0;

            foreach (var emailAddress in viewModel.EmailAddresses)
            {
                var invitation = new Invitation
                {
                    CompetitionId = viewModel.CompetitionId,
                    Email = emailAddress,
                    Token = Guid.NewGuid().ToString()
                };

                try
                {
                    MailHelper.SendEmail(emailAddress,
                        string.Format(
                            "You have been invited to participate in a competition! <a href='{0}'>Accept your invite now</a>!",
                            Url.Action("accept", "invitations", new {token = invitation.Token}, "https")));

                    _invitationRepository.Create(invitation);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Format("EmailAddresses[{0}]", loopIndex), string.Format("Error sending email to {0}: {1}", emailAddress, e.Message));
                }

                loopIndex++;
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
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