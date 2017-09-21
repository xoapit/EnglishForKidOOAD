using APIEnglishForKid.Models;
using APIEnglishForKid.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIEnglishForKid.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _unitOfWork = UnitOfWork.GetInstance();
        EnglishDatabase db = new EnglishDatabase();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
