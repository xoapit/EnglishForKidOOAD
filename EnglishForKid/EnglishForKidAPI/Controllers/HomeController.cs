using EnglishForKidAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKidAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ReflectionController reflection = new ReflectionController();

            string result = "";

            // Get user for user, default by admin
            List<string> listAction = reflection.GetActionsForUser();

            foreach (var action in listAction)
            {
                result += "<ul>" + action + "</ul>";
            }

            result += "<ul>";

            // get all controllers and actions for each controller
            foreach (var controller in reflection.GetControllers())
            {
                result += "<li>" + controller.Name + "<ul>";
                foreach (var action in reflection.GetActions(controller))
                {
                    result += "<li>" + action + "</li>";
                }
                result += "</ul></li>";
            }

            result += "</ul>";

            ViewBag.result = result;

            return View();
        }
        public ActionResult Warning()
        {
            return View();
        }
    }
}
