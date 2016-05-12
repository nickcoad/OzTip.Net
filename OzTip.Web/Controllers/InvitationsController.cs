using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OzTip.Interfaces;
using OzTip.Models;
using OzTip.Web.Models.Invitations;

namespace OzTip.Web.Controllers
{
    public class InvitationsController : OzTipControllerBase
    {
        private readonly IRepository<Competition> _competitionRepository;
        private readonly IRepository<Invitation> _invitationRepository;
        private readonly IRepository<User> _userRepository;
        private readonly ApplicationUserManager _userManager;

        public InvitationsController(
            IRepository<Competition> competitionRepository,
            IRepository<Invitation> invitationRepository,
            IRepository<User> userRepository,
            ApplicationUserManager userManager)
            : base(userManager)
        {
            _competitionRepository = competitionRepository;
            _invitationRepository = invitationRepository;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        // GET: competitions/accept/?token={token}
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Accept(string token)
        {
            var invitation = _invitationRepository.GetWhere(inv => inv.Token == token).FirstOrDefault();
            if (invitation == null)
                return HttpNotFound();

            var competition = _competitionRepository.GetById(invitation.CompetitionId);
            if (competition == null)
                return HttpNotFound();

            var user = _userRepository.GetWhere(us => us.Email.Equals(invitation.Email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (user == null)
            {
                var acceptNewUserViewModel = new AcceptNewUserViewModel
                {
                    Competition = competition,
                    Token = token,
                    Email = invitation.Email
                };

                return View("accept-new-user", acceptNewUserViewModel);
            }

            var acceptExistingUserViewModel = new AcceptExistingUserViewModel
            {
                Competition = competition,
                User = user,
                Token = token
            };
            
            return RedirectToAction("accept-existing-user", new { token });
        }

        [HttpGet]
        [ActionName("accept-existing-user")]
        public ActionResult AcceptExistingUser(string token)
        {
            var invitation = _invitationRepository.GetWhere(inv => inv.Token == token).FirstOrDefault();
            if (invitation == null)
                return HttpNotFound();

            var acceptExistingUserViewModel = new AcceptExistingUserViewModel();

            return View("accept-existing-user", acceptExistingUserViewModel);
        }

        [HttpPost]
        [ActionName("accept-existing-user")]
        public ActionResult AcceptExistingUser(AcceptExistingUserViewModel viewModel)
        {
            var invitation = _invitationRepository.GetWhere(inv => inv.Token == viewModel.Token).FirstOrDefault();
            if (invitation == null)
                return HttpNotFound();

            if (LoggedInUser.Email != invitation.Email)
            {
                return Error("The token you have supplied does not match a valid invitation.");
            }

            // We have the correct user logged in. Add them to the competition.
            var competition = _competitionRepository.GetById(invitation.CompetitionId);
            competition.Users.Add(LoggedInUser);
            _competitionRepository.SaveChanges();
            
            AddToastNotification("success", "You have successfully accepted the invitation to join!");
            return RedirectToAction("index", "home");
        }

        // GET: competitions/accept-new-user
        [HttpPost]
        [AllowAnonymous]
        [ActionName("accept-new-user")]
        public async Task<ActionResult> AcceptNewUser(AcceptNewUserViewModel viewModel)
        {
            var invitation = _invitationRepository.GetWhere(inv => inv.Token == viewModel.Token).FirstOrDefault();
            if (invitation == null)
                return HttpNotFound();

            var competition = _competitionRepository.GetById(invitation.CompetitionId);

            if (!ModelState.IsValid)
            {
                viewModel.Competition = competition;

                return View(viewModel);
            }

            var newUser = new User
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(newUser, viewModel.Password);
            var createdUser = _userRepository.GetById(newUser.Id);

            if (!result.Succeeded)
            {
                AddToastNotification("error", "Something has gone terribly wrong!");
                return RedirectToAction("index", "home");
            }

            try
            {
                competition.Users.Add(createdUser);
                _competitionRepository.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            
            AddToastNotification("success", "You have successfully accepted the invitation to join, sign in to continue!");

            return RedirectToAction("index", "home");
        }
    }
}