using OzTip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace OzTip.Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller.Equals(currentController, StringComparison.CurrentCultureIgnoreCase) && action.Equals(currentAction, StringComparison.CurrentCultureIgnoreCase) ?
                cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

        public static HtmlString TeamDetailsLink(this HtmlHelper html, int teamId, string teamName)
        {
            return new HtmlString(string.Format("<a href=\"{0}\">{1}</a>", teamId, teamName));
        }

        public static HtmlString TeamDetailsLink(this HtmlHelper html, Team team)
        {
            return TeamDetailsLink(html, team.Id, team.LongName);
        }
    }
}
