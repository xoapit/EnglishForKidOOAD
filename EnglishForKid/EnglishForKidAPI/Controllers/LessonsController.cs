using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EnglishForKidAPI.Models;
using EnglishForKidAPI.Models.ViewModels;
using EnglishForKidAPI.Models.Factory;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace EnglishForKidAPI.Controllers
{
    [RoutePrefix("")]
    public class LessonsController : BaseApiController
    {
        // GET: api/Lessons
        [Route("api/lessons")]
        public IQueryable<Lesson> GetLessons()
        {
            return db.Lessons;
        }

        [HttpGet]
        [Route("api/lessons")]
        public List<BaseLessonInfoViewModel> GetLessonsByCategoryName(int limit)
        {
            List<BaseLessonInfoViewModel> baseLessons = new List<BaseLessonInfoViewModel>();
            List<Lesson> lessons = db.Lessons.Take(limit).OrderByDescending(x => x.CreateAt).ToList();
            if (lessons != null)
            {
                foreach (Lesson lesson in lessons)
                {
                    baseLessons.Add(ModelFactory.GetBaseLessonInfoViewModel(lesson));
                }
            }
            return baseLessons;
        }

        // GET: api/Lessons/5
        [HttpGet]
        [Route("api/lessons/{id}")]
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult GetLesson(Guid id)
        {
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        [HttpGet]
        [Route("api/lessons")]
        public List<BaseLessonInfoViewModel> GetLessonsByCategoryName(string categoryName, int start = 0, int take = 10)

        {
            List<BaseLessonInfoViewModel> baseLessons = new List<BaseLessonInfoViewModel>();
            List<Lesson> lessons = db.Lessons.Where(x => x.Category.Name == categoryName).ToList();

            if (lessons != null)
            {
                int remainingNumber = lessons.Count() - start;
                if (remainingNumber < take)
                {
                    take = remainingNumber;
                }
                lessons = lessons
               .OrderByDescending(x => x.CreateAt)
               .Skip(start)
               .Take(take)
               .ToList();
                foreach (Lesson lesson in lessons)
                {
                    baseLessons.Add(ModelFactory.GetBaseLessonInfoViewModel(lesson));
                }
            }
            return baseLessons;
        }

        [Route("api/lessons/numberOfLessons")]
        [HttpGet]
        public int GetNumberOfLessonsByCategoryName(string categoryName)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.Category.Name == categoryName).ToList();
            return lessons.Count();
        }

        [Authorize]
        // PUT: api/Lessons/5
        [Route("api/lessons/{id}")]
        
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLesson(Guid id, Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lesson.ID)
            {
                return BadRequest();
            }

            db.Entry(lesson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [Authorize]
        // POST: api/Lessons
        [HttpPost]
        [Route("api/Lessons")]
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult PostLesson(Lesson lesson)
        {
            Lesson item = new Lesson()
            {
                ID = Guid.NewGuid(),
                Answer = lesson.Answer,
                ApplicationUserID = lesson.ApplicationUserID,
                CategoryID = lesson.CategoryID,
                Content = lesson.Content,
                CreateAt = DateTime.Now,
                Discussion = lesson.Discussion,
                Exercise = lesson.Exercise,
                Image = lesson.Image,
                LevelID = lesson.LevelID,
                Tag = lesson.Tag,
                Title = lesson.Title
            };

            db.Lessons.Add(item);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException )
            {
                if (LessonExists(lesson.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception )
            {

            }

            return Ok(lesson);
        }

        [Authorize]
        // DELETE: api/Lessons/5
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult DeleteLesson(Guid id)
        {
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return NotFound();
            }

            db.Lessons.Remove(lesson);
            db.SaveChanges();

            return Ok(lesson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LessonExists(Guid id)
        {
            return db.Lessons.Count(e => e.ID == id) > 0;
        }

        [Route("PostImage")]
        public Task<HttpResponseMessage> Post()
        {
            List<string> savedFilePath = new List<string>();
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string rootPath = HttpContext.Current.Server.MapPath("~/Img");
            var provider = new MultipartFileStreamProvider(rootPath);
            var task = Request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<HttpResponseMessage>(t =>
                {
                    if (t.IsCanceled || t.IsFaulted)
                    {
                        Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                    }
                    foreach (MultipartFileData item in provider.FileData)
                    {
                        try
                        {
                            string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                            string newFileName = Guid.NewGuid() + Path.GetExtension(name);
                            File.Move(item.LocalFileName, Path.Combine(rootPath, newFileName));

                            Uri baseuri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                            string fileRelativePath = "~/Img/" + newFileName;
                            Uri fileFullPath = new Uri(baseuri, VirtualPathUtility.ToAbsolute(fileRelativePath));
                            savedFilePath.Add(fileFullPath.ToString());
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message;
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.Created, savedFilePath);
                });
            return task;
        }

    }
}