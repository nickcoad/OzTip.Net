using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using OzTip.Core.Interfaces;
using OzTip.Data;
using OzTip.Models;
using OzTip.Web.Models.Competitions;
using OzTip.Web.Models.Invitations;

namespace OzTip.Web.Controllers
{
    public class InvitationsController : OzTipControllerBase
    {
        private readonly IRepository<Competition> _competitionRepository = new RepositoryBase<Competition>();
        private readonly IRepository<Invitation> _invitationRepository = new RepositoryBase<Invitation>();
        private readonly IRepository<User> _userRepository;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public InvitationsController()
        {
            _competitionRepository = new RepositoryBase<Competition>(context);
            _invitationRepository = new RepositoryBase<Invitation>(context);
            _userRepository = new RepositoryBase<User>(context);
        }

        // GET: competitions/accept/?token={token}
        [HttpGet]
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

            return View("accept-existing-user", acceptExistingUserViewModel);
        }

        // GET: competitions/accept-new-user
        [HttpPost]
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

            var result = await UserManager.CreateAsync(newUser, viewModel.Password);
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