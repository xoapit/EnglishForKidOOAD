using EnglishForKid.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishForKid.Service;
using EnglishForKid.Models;
using EnglishForKid.Models.ViewModels;
using System.Net.Http;

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
            InitCreate();
            return View();
        }

        private void InitCreate()
        {
            //Get list Categories
            CategoryDataStore categoryDataStore = new CategoryDataStore();
            List<Category> categories = categoryDataStore.GetItemsAsync().Result;
            ViewBag.ListCategories = categories;
            ViewBag.Categories = categories.Select(x => x.Name).ToList();

            //Get list Level
            LevelDataStore levelDataStore = new LevelDataStore();
            List<Level> levels = levelDataStore.GetItemsAsync().Result;
            ViewBag.ListLevels = levels;
            ViewBag.Levels = levels.Select(x => x.Value.ToString()).ToList();
        }

        // POST: Teacher/Lesson/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            InitCreate();
            List<Level> levels = ViewBag.ListLevels;
            List<Category> categories = ViewBag.ListCategories;
            try
            {
                var title = collection["Title"];
                var categoryValue = collection["CategoryID"];
                var levelValue = collection["LevelID"];

                var image = collection["Image"];
                var content = Request.Unvalidated.Form.Get("Content");
                var discussion = collection["Discussion"];
                var exercise = collection["Exercise"];
                var answer = collection["Answer"];

                Guid categoryID = categories.Where(x => x.Name.Equals(categoryValue)).First().ID;
                Guid levelID = levels.Where(x => x.Value.Equals(Int32.Parse(levelValue))).First().ID;

                Lesson lesson = new Lesson
                {
                    ID = Guid.NewGuid(),
                    CreateAt = DateTime.Now,
                    Tag = "",
                    ApplicationUserID = Request.Cookies["Id"].Value,
                    Title = title,
                    CategoryID = categoryID,
                    LevelID = levelID,
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

        // GET: Teacher/Lesson/Edit/5
        public ActionResult Edit(string id)
        {
            InitCreate();
            Lesson lesson = lessonDataStore.GetItemAsync(id).Result;
            return View("Edit", lesson);
        }

        // POST: Teacher/Lesson/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection, Lesson lesson1)
        {
            InitCreate();
            List<Level> levels = ViewBag.ListLevels;
            List<Category> categories = ViewBag.ListCategories;


            var title = collection["Title"];
            var categoryValue = collection["CategoryID"];
            var levelValue = collection["LevelID"];

            var image = collection["Image"];
            //HttpPostedFileBase image;
            var content = Request.Unvalidated.Form.Get("Content");
            var discussion = collection["Discussion"];
            var exercise = collection["Exercise"];
            var answer = collection["Answer"];

            Guid categoryID = categories.Where(x => x.Name.Equals(categoryValue)).First().ID;
            Guid levelID = levels.Where(x => x.Value.Equals(Int32.Parse(levelValue))).First().ID;



            using (var client = new HttpClient())
            {
                using (var content1 = new MultipartFormDataContent())
                {
                    if (lesson1.ImageFile != null)
                    {
                        byte[] Bytes = new byte[lesson1.ImageFile.InputStream.Length + 1];
                        lesson1.ImageFile.InputStream.Read(Bytes, 0, Bytes.Length);
                        var fileContent = new ByteArrayContent(Bytes);
                        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = lesson1.ImageFile.FileName };
                        content1.Add(fileContent);
                        var requestUri = "http://localhost:50828/PostImage";
                        var result1 = client.PostAsync(requestUri, content1).Result;
                        if (result1.StatusCode == System.Net.HttpStatusCode.Created)
                        {
                            List<string> m = result1.Content.ReadAsAsync<List<string>>().Result;
                            image = m[0];
                            ViewBag.Success = m.FirstOrDefault();

                        }
                        else
                        {
                            ViewBag.Failed = "Failed !" + result1.Content.ToString();
                        }
                    }
                }
            }

            Lesson lesson = new Lesson
            {
                ID = id,
                CreateAt = DateTime.Now,
                Tag = "",
                ApplicationUserID = Request.Cookies["Id"].Value,
                Title = title,
                CategoryID = categoryID,
                LevelID = levelID,
                Image = image,
                Content = content,
                Discussion = discussion,
                Exercise = exercise,
                Answer = answer
            };

            var result = lessonDataStore.UpdateItemAsync(lesson).Result;
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(lesson);
            }


        }

        // POST: Teacher/Lesson/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            bool result = lessonDataStore.DeleteItemAsync(id).Result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

