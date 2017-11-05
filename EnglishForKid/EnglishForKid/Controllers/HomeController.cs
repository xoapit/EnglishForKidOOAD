using EnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using System.Web.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using EnglishForKid.Service;
using EnglishForKid.Models.ViewModel;
using EnglishForKid.Constants;
using EnglishForKid.Models.ViewModels;

namespace EnglishForKid.Controllers
{
    public class HomeController : Controller
    {
        LessonDataStore lessonDataStore = new LessonDataStore();
        public ActionResult Index()
        {
            LessonDataStore lessonDataStore = new LessonDataStore();
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetFourTeachers()
        {
            AccountDataStore accountDataStore = new AccountDataStore();
            List<UserReturnModel> teachers = accountDataStore.GetAccountsByRoleNameAsync(ApplicationConfig.TeacherRole).Result;
            ViewBag.Teachers = teachers;
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetLessonIndex()
        {
            List<Lesson> lessons = lessonDataStore.GetItemsAsync().Result;
            ViewBag.BaseLessonInfoViewModels1 = lessons.Take(3);
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddFeedback(FormCollection form)
        {
            FeedbackDataStore feedbackDataStore = new FeedbackDataStore();
            string name = form["Name"];
            string subject = form["Subject"];
            string email = form["Email"];
            string message = form["Message"];
            Feedback feedback = new Feedback()
            {
                ID = Guid.NewGuid(),
                Content = message,
                CreateAt = DateTime.Now,
                Email = email,
                FullName = name,
                Title = subject
            };
            var result = feedbackDataStore.AddItemAsync(feedback).Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetCount()
        {
            ViewCountDataStore viewCountDataStore = new ViewCountDataStore();
            var result = viewCountDataStore.GetCountAsync().Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLesson()
        {
            LessonDataStore lessonDataStore = new LessonDataStore();
            var result = lessonDataStore.GetItemsAsync().Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}