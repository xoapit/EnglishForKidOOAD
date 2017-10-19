using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKidAPI.Helper
{
    public class AuthorizeController : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string username = HttpContext.Current.User.Identity.Name;

            // Gia su cac action ma user duoc truy cap
            string[] listPermission = { "GetUser", "GetBusiness" };
            string actionName = filterContext.ActionDescriptor.ActionName;

            if (!listPermission.Contains(actionName))
            {
                filterContext.Result = new RedirectResult("~/Home/Warning/");
            }
        }
    }
}