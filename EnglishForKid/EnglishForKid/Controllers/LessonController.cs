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

        public ActionResult DetailOfLesson(Guid id)
        {
            Lesson lesson = lessonDataStore.GetItemAsync(id).Result;
            ViewBag.Lesson = lesson;
            return View();
        }

        public ActionResult ListLessonByCategory(String categoryName = "Reading")
        {
            List<BaseLessonInfoViewModel> baseLessonInfoViewModels = lessonDataStore.GetBaseLessonInfoViewModelsByCategoryNameAsync(categoryName).Result;
            ViewBag.BaseLessonInfoViewModels = baseLessonInfoViewModels;
            return View();
        }

    }
}