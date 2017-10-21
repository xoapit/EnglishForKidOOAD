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

namespace EnglishForKidAPI.Controllers
{
    public class FeedbacksController : BaseApiController
    {

        // GET: api/Feedbacks
        public IQueryable<Feedback> GetFeedbacks()
        {
            return db.Feedbacks;
        }

        // GET: api/Feedbacks/5
        [ResponseType(typeof(Feedback))]
        public IHttpActionResult GetFeedback(Guid id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // PUT: api/Feedbacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeedback(Guid id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.ID)
            {
                return BadRequest();
            }

            db.Entry(feedback).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
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

        // POST: api/Feedbacks
        [ResponseType(typeof(Feedback))]
        public IHttpActionResult PostFeedback(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Feedbacks.Add(feedback);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FeedbackExists(feedback.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = feedback.ID }, feedback);
        }

        // DELETE: api/Feedbacks/5
        [ResponseType(typeof(Feedback))]
        public IHttpActionResult DeleteFeedback(Guid id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }

            db.Feedbacks.Remove(feedback);
            db.SaveChanges();

            return Ok(feedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedbackExists(Guid id)
        {
            return db.Feedbacks.Count(e => e.ID == id) > 0;
        }
    }
}