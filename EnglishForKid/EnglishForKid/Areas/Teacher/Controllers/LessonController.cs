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

        ////Add lesson
        //[HttpPost]
        //public ActionResult AddLesson (String Title, String CategoryID, String Content, String Image, String Discusson, String Exercise, String Anwser, String Tag, String LevelID, String ApplicationID)
        //{
        //    Lesson lesson = new Lesson()
        //    {


        //        ID = Guid.NewGuid(),
        //        Title = Title,
        //        CategoryID = new Guid(CategoryID),
        //        Image = Image,
        //        Content = Content,
        //        Discussion = Discusson,
        //        Exercise = Exercise,
        //        Answer = Anwser,
        //        CreateAt = DateTime.Now,
        //        Tag = Tag,
        //        LevelID = new Guid(LevelID),
        //        ApplicationUserID = ApplicationID,
        //    };
        //    LessonDataStore lessonDataStore = new LessonDataStore();
        //    bool result = lessonDataStore.AddItemAsync(lesson).Result;
        //    return Json(new { status = result}, JsonRequestBehavior.AllowGet );  
        //}
       
        }
        // Update Lesson
        [HttpPost]
        public ActionResult UpdateLesson(Lesson item)
        {

            bool result = lessonDataStore.UpdateItemAsync(item).Result;
            return Json(new { sattus = result }, JsonRequestBehavior.AllowGet);
        }

        // GET: Teacher/Lesson/Details/5
        public ActionResult Details(String id)
        {
            Lesson lesson = lessonDataStore.GetItemAsync(id).Result;
            ViewBag.Lesson = lesson;
            return View(lesson);

        }

        // GET: Teacher/Lesson/Create
        public ActionResult Create( )
        {
            return View();
        }

        // POST: Teacher/Lesson/Create
        [HttpPost]
        public ActionResult Create(Lesson lesson)
        {

            try
            {
                string lessonID = Request.Form["lessonID"];
                string title = Request.Form["title"];
                string categoryID = Request.Form["category"];
                string image = Request.Form["image"];
                string content = Request.Form["content"];
                string discussion = Request.Form["discussion"];
                string exercise = Request.Form["exercise"];
                string answer = Request.Form["answer"];
                string leveID = Request.Form["levelID"];

                lesson = new Lesson()
                {

                    ID = new Guid(lessonID),
                    Title = title,
                    CategoryID = new Guid(categoryID),
                    Image = image,
                    Content = content,
                    Discussion = discussion,
                    Exercise = exercise,
                    LevelID = new Guid(leveID),
                    CreateAt = DateTime.Now,

                };
                LessonDataStore lessonDataStore = new LessonDataStore();
                bool result = lessonDataStore.AddItemAsync(lesson).Result;
                return Json(result, JsonRequestBehavior.AllowGet );

            }
            catch
            {
                bool result = false;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Teacher/Lesson/Edit/5
        public ActionResult Edit(String id)
        {
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
                string lessonID = Request.Form["lessonID"];
                string title = Request.Form["title"];
                string categoryID = Request.Form["category"];
                string image = Request.Form["image"];
                string content = Request.Form["content"];
                string discussion = Request.Form["discussion"];
                string exercise = Request.Form["exercise"];
                string answer = Request.Form["answer"];
                string leveID = Request.Form["levelID"];

                Lesson lesson = new Lesson()
                {

                    ID = new Guid(lessonID),
                    Title = title,
                    CategoryID = new Guid(categoryID),
                    Image = image,
                    Content = content,
                    Discussion = discussion,
                    Exercise = exercise,
                    LevelID = new Guid(leveID),
                };
                bool result = lessonDataStore.UpdateItemAsync(lesson).Result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                bool result = false;
                return Json(result, JsonRequestBehavior.AllowGet);
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
