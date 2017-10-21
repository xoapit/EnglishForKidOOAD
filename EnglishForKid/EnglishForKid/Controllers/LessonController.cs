using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKid.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult ListOfLesson()
        {
            return View();
        }

        public ActionResult DetailOfLesson()
        {
            return View();
        }
    }
}