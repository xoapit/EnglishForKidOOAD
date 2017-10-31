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

namespace EnglishForKidAPI.Controllers
{
    public class LessonsController : BaseApiController
    {
        // GET: api/Lessons
        [Route("api/lessons")]
        public IQueryable<Lesson> GetLessons()
        {
            return db.Lessons;
        }

        // GET: api/Lessons/5
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

        [ResponseType(typeof(BaseLessonInfoViewModel))]
        public IHttpActionResult GetLessonsByCategoryName(string categoryName)
        {
            List<BaseLessonInfoViewModel> baseLessons = new List<BaseLessonInfoViewModel>();
            List<Lesson> lessons = db.Lessons.Where(x => x.Category.Name == categoryName).ToList();
            if (lessons == null)
            {
                return NotFound();
            }
            foreach (Lesson lesson in lessons)
            {
                baseLessons.Add(ModelFactory.GetBaseLessonInfoViewModel(lesson));
            }
            return Ok(baseLessons);
        }

        // PUT: api/Lessons/5
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

        // POST: api/Lessons
        [HttpPost]
        [Route("api/Lessons")]
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult PostLesson(Lesson lesson)
        { 
            db.Lessons.Add(lesson);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
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

            return Ok(lesson);
        }

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
    }
}