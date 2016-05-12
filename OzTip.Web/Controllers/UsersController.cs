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
using OzTip.Web.Models.Users;

namespace OzTip.Web.Controllers
{
    public class UsersController : OzTipControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Team> _teamRepository;

        public UsersController(
            IRepository<User> userRepository,
            IRepository<Team> teamRepository,
            ApplicationUserManager userManager)
            : base(userManager)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }

        // GET: users/details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        // GET: users/edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                return HttpNotFound();

            var viewModel = new EditUserViewModel
            {
                UserId = user.Id,
                TeamId = user.TeamId,
                GivenName = user.GivenName,
                Surname = user.Surname,
                Teams = _teamRepository.Get().OrderBy(te => te.ShortName).ToList()
            };
            return View(viewModel);
        }

        // POST: users/edit/{id}
        [HttpPost]
        public ActionResult Edit(EditUserViewModel viewModel)
        {
            var user = _userRepository.GetById(viewModel.UserId);
            if (user == null)
                return HttpNotFound();

            user.GivenName = viewModel.GivenName;
            user.Surname = viewModel.Surname;
            user.TeamId = viewModel.TeamId;

            _userRepository.SaveChanges();

            return RedirectToAction("details", "users", new { id = viewModel.UserId });
        }
    }
}