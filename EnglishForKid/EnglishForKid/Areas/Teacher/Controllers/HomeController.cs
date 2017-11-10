using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishForKid.Models;
using EnglishForKid.Service;

namespace EnglishForKid.Areas.Teacher.Controllers
{


    public class HomeController : Controller
    {
        LessonDataStore lessonDataStore = new LessonDataStore();
        // GET: Teacher/Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Lesson");
        }

        // GET: Teacher/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Teacher/Home/Create
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

        // POST: Teacher/Home/Create
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
                    //Image = image,
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

        // GET: Teacher/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Home/Delete/5
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
