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

            string result = "<ul>";

            foreach (var controller in reflection.GetControllers())
            {
                result += "<li>" + controller.Name+ "<ul>";
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
