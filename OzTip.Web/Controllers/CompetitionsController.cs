using OzTip.Interfaces;
using OzTip.Data;
using OzTip.Models;
using OzTip.Web.Models.Competitions;
using System;
using System.Collections.Generic;
using System.IO;
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

            // Is this user participating in the competition?
            ViewBag.UserIsInCompetition = competition.Users.Any(us => us.Id == LoggedInUser.Id);

            // Is this user the owner of the competition?
            ViewBag.UserIsOwner = competition.Owner.Id == LoggedInUser.Id;

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
                Password = viewModel.Password,
                IsPrivate = viewModel.IsPrivate,
                UserId = LoggedInUser.Id,
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

        // GET: competitions/join/{id}
        [HttpGet]
        public ActionResult Join(int id)
        {
            var competition = _competitionRepository.GetById(id);
            if (competition == null)
                return HttpNotFound();

            var viewModel = new JoinCompetitionViewModel
            {
                CompetitionId = competition.Id,
                CompetitionName = competition.Name,
                CompetitionDescription = competition.Description,
                CompetitionIsPrivate = competition.IsPrivate
            };
            return View(viewModel);
        }

        // POST: competitions/join/{id}
        [HttpPost]
        public ActionResult Join(JoinCompetitionViewModel viewModel)
        {
            var competition = _competitionRepository.GetById(viewModel.CompetitionId);
            if (competition == null)
                return HttpNotFound();

            viewModel.CompetitionId = competition.Id;

            if (!competition.IsPrivate || competition.Password == viewModel.Password)
            {
                competition.Users.Add(LoggedInUser);
                _competitionRepository.SaveChanges();

                return RedirectToAction("details", "competitions", new { id = viewModel.CompetitionId });
            }
                

            ModelState.AddModelError("Password", "The password you have entered is incorrect.");
            return View(viewModel);
        }

        // GET: competitions/leave/{id}
        [HttpGet]
        public ActionResult Leave(int id)
        {
            var competition = _competitionRepository.GetById(id);
            if (competition == null)
                return HttpNotFound();

            if (competition.Owner.Id == LoggedInUser.Id)
                ModelState.AddModelError(string.Empty, "You cannot leave a competition you created, you must close the competition or transfer ownership to another player.");

            var viewModel = new LeaveCompetitionViewModel
            {
                CompetitionId = competition.Id,
                CompetitionName = competition.Name,
                ConfirmIsTicked = false
            };
            return View(viewModel);
        }

        // POST: competitions/leave/{id}
        [HttpPost]
        public ActionResult Leave(LeaveCompetitionViewModel viewModel)
        {
            var competition = _competitionRepository.GetById(viewModel.CompetitionId);
            if (competition == null)
                return HttpNotFound();

            if (!viewModel.ConfirmIsTicked)
                ModelState.AddModelError("ConfirmIsTicked", "You must confirm your decision to leave the competition.");

            if (competition.Owner.Id == LoggedInUser.Id)
                ModelState.AddModelError(string.Empty, "You cannot leave a competition you created, you must close the competition or transfer ownership to another player.");

            if (!ModelState.IsValid)
                return View(viewModel);

            competition.Users.Remove(LoggedInUser);
            _competitionRepository.SaveChanges();

            return RedirectToAction("details", "competitions", new { id = viewModel.CompetitionId });
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