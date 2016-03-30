using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OzTip.Models;
using System.Web;
using System.Web.Mvc;

namespace OzTip.Web.Controllers
{
    public class OzTipControllerBase : Controller
    {
        public User LoggedInUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId<int>());
        
        // GET: OzTipControllerBase
        public ActionResult Success(string message)
        {
            return View("success", null, message);
        }
    }
}