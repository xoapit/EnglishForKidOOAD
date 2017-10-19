using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishForKid.Service;
using EnglishForKid.Models;

namespace EnglishForKid.Areas.Admin.Controllers
{
    public class LessonController : Controller
    {
        private LessonDataStore lessonDataStore = new LessonDataStore();
        // GET: Admin/Lesson
        public ActionResult Index()
        {
           List<Lesson> lessons = lessonDataStore.GetItemsAsync().Result;
           ViewBag.Lessons = lessons;
            return View();
        }

        // GET: Admin/Lesson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Lesson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Lesson/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Lesson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Lesson/Edit/5
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

        // GET: Admin/Lesson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Lesson/Delete/5
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
