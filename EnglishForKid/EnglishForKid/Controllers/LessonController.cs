using EnglishForKid.Models;
using EnglishForKid.Models.ViewModels;
using EnglishForKid.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKid.Controllers
{
    public class LessonController : Controller
    {
        LessonDataStore lessonDataStore = new LessonDataStore();
        RateDataStore rateDataStore = new RateDataStore();
        // GET: Lesson
        public ActionResult ListOfLesson()
        {
            return View();
        }

        public ActionResult DetailOfLesson(String id)
        {
            Lesson lesson = lessonDataStore.GetItemAsync(id).Result;
            ViewBag.Lesson = lesson;
            ViewBag.IsLogin = IsLogin(this.Request);
            float averageRating = rateDataStore.GetAverageRateByLessonIDAsync(lesson.ID).Result;
            ViewBag.AverageRating = averageRating;

            if (IsLogin(Request))
            {
                string userID = Request.Cookies["id"]?.Value;
                Rate rate = rateDataStore.GetRateByLessonAndUserAsync(lesson.ID, userID).Result;
                ViewBag.MyRate = rate;
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddRate(FormCollection form)
        {
            Guid lessonID = new Guid(form["LessonID"]);
            string level = form["level"];

            string userID = Request.Cookies["id"].Value;
            Rate rate = rateDataStore.GetRateByLessonAndUserAsync(lessonID, userID).Result;
            if (rate == null)
            {
                rate = new Rate()
                {
                    ID = Guid.NewGuid(),
                    Level = 0,
                    ApplicationUserID = userID,
                    CreateAt = DateTime.Now,
                    LessonID = lessonID
                };
            }
            rate.Level = float.Parse(level);
            bool result = rateDataStore.AddItemAsync(rate).Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetComments(string lessonId)
        {
            //lessonId = "2336b7b0-6eed-490d-9173-13c40239fedc";
            CommentDataStore commentDataStore = new CommentDataStore();
            List<Comment> comments = new List<Comment>();
            comments = commentDataStore.GetCommentsAcyncByLessonIdAsync(new Guid(lessonId)).Result;
            ViewBag.Comments = comments;
            return View();
        }

        [HttpPost]
        public ActionResult AddComment(FormCollection form)
        {
            string applicationUserID = Request.Cookies["Id"].Value;
            string content = form["Content"];
            string lessonId = form["LessonID"];
            Comment comment = new Comment()
            {
                ApplicationUserID = applicationUserID,
                Content = content,
                CreateAt = DateTime.Now,
                ID = Guid.NewGuid(),
                LessonID = new Guid(lessonId)
            };

            CommentDataStore commentDataStore = new CommentDataStore();
            bool result = commentDataStore.AddItemAsync(comment).Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListLessonByCategory(string categoryName)
        {
            List<BaseLessonInfoViewModel> baseLessonInfoViewModels = lessonDataStore.GetBaseLessonInfoViewModelsByCategoryNameAsync(categoryName).Result;
            ViewBag.BaseLessonInfoViewModels = baseLessonInfoViewModels;
            return View();
        }

        public bool IsLogin(HttpRequestBase Request)
        {
            string id = Request.Cookies["id"]?.Value;
            return !string.IsNullOrEmpty(id);
        }
    }
}