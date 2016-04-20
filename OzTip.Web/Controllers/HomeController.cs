using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OzTip.Models;

namespace OzTip.Web.Controllers
{
    public class HomeController : OzTipControllerBase
    {
        public HomeController(
            ApplicationUserManager userManager)
            : base(userManager)
        {
            
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (LoggedInUser != null)
                return RedirectToAction("index", "dashboard");

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}