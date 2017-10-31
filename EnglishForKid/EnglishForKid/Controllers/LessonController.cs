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
        // GET: Lesson
        public ActionResult ListOfLesson()
        {
            return View();
        }

        public ActionResult DetailOfLesson(String id)
        {
            Lesson lesson = lessonDataStore.GetItemAsync(id).Result;
            ViewBag.Lesson = lesson;
            return View();
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

    }
}