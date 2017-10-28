using EnglishForKid.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishForKid.Service;
using EnglishForKid.Models;

namespace EnglishForKid.Areas.Teacher.Controllers
{
    public class LessonController : Controller
    {
        LessonDataStore lessonDataStore = new LessonDataStore();
        // GET: Teacher/Lesson
        public ActionResult Index()
        {

            List<Lesson> lessons = lessonDataStore.GetItemsAsync().Result;
            ViewBag.Lessons = lessons;
            return View();
        }

        //delete lesson
        [HttpPost]
        public ActionResult DeleteLesson(Guid id)
        {
            bool result = lessonDataStore.DeleteItemAsync(id).Result;
            return Json(new { status = result }, JsonRequestBehavior.AllowGet);
        }

        

        // GET: Teacher/Lesson/Details/5
        public ActionResult Details(String id)
        {
            Lesson lesson = lessonDataStore.GetItemAsync(id).Result;
            ViewBag.Lesson = lesson;
            return View(lesson);

        }

        // GET: Teacher/Lesson/Create
        public ActionResult Create()
        {
            //Get list Categories
            CategoryDataStore categoryDataStore = new CategoryDataStore();
            List<Category> categories = categoryDataStore.GetItemsAsync().Result;
            ViewBag.Categories = categories.Select(x => x.Name).ToList();

            //Get list Level
            LevelDataStore levelDataStore = new LevelDataStore();
            List<Level> levels = levelDataStore.GetItemsAsync().Result;
            ViewBag.Levels = levels.Select(x => x.Value.ToString()).ToList();
            return View();
        }

        // POST: Teacher/Lesson/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                var title = collection["Title"];
                var category = collection["Category"];
                var level = collection["Level"];
                var image = collection["Image"];
                var content = collection["Content"];
                var discussion = collection["Discussion"];
                var exercise = collection["Excercise"];
                var answer = collection["Answer"];

                Lesson lesson = new Lesson
                {
                    Title = title,
                    CategoryID = new Guid(category),
                    LevelID = new Guid(level),
                    Image = image,
                    Content = content,
                    Discussion = discussion,
                    Exercise = exercise,
                    Answer = answer
                };

                var result = lessonDataStore.AddItemAsync(lesson).Result;
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Lesson/Edit/5
        public ActionResult Edit(String id)
        {
            //Get list Categories
            CategoryDataStore categoryDataStore = new CategoryDataStore();
            List<Category> categories = categoryDataStore.GetItemsAsync().Result;
            ViewBag.Categories = categories.Select(x => x.Name).ToList();

            //Get list Level
            LevelDataStore levelDataStore = new LevelDataStore();
            List<Level> levels = levelDataStore.GetItemsAsync().Result;
            ViewBag.Levels = levels.Select(x => x.Value.ToString()).ToList();

            Lesson lesson = lessonDataStore.GetItemAsync(id).Result;
            ViewBag.Lesson = lesson;
            return View();
        }

        // POST: Teacher/Lesson/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, FormCollection collection)
        {
            try
            {
                var title = collection["Title"];
                var category = collection["Category"];
                var level = collection["Level"];
                var image = collection["Image"];
                var content = collection["Content"];
                var discussion = collection["Discussion"];
                var exercise = collection["Excercise"];
                var answer = collection["Answer"];

                Lesson lesson = new Lesson
                {
                    Title = title,
                    CategoryID = new Guid(category),
                    LevelID = new Guid(level),
                    Image = image,
                    Content = content,
                    Discussion = discussion,
                    Exercise = exercise,
                    Answer = answer
                };

                var result = lessonDataStore.AddItemAsync(lesson).Result;
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

            // GET: Teacher/Lesson/Delete/5
            public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Teacher/Lesson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

