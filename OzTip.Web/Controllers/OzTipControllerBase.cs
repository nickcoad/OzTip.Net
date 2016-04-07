using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OzTip.Models;
using System.Web;
using System.Web.Mvc;
using OzTip.Web.Models;

namespace OzTip.Web.Controllers
{
    public class OzTipControllerBase : Controller
    {
        private readonly ApplicationUserManager _userManager;

        public User LoggedInUser
        {
            get
            {
                return _userManager.FindById(System.Web.HttpContext.Current.User.Identity.GetUserId<int>());
            }
        }

        public OzTipControllerBase(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: OzTipControllerBase
        public ActionResult Success(string message)
        {
            return View("success", null, message);
        }

        // GET: OzTipControllerBase
        public ActionResult Error(string message)
        {
            return View("error", null, message);
        }

        public void AddToastNotification(string type, string message)
        {
            TempData["ToastNotification"] = new ToastNotification
            {
                Type = type,
                Message = message
            };
        }
    }
}