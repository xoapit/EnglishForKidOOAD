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
    public class AnswerSurveysController : BaseApiController
    {
        // GET: api/AnswerSurveys
        public IQueryable<AnswerSurvey> GetAnswerSurveys()
        {
            return db.AnswerSurveys;
        }

        // GET: api/AnswerSurveys/5
        [ResponseType(typeof(AnswerSurvey))]
        public IHttpActionResult GetAnswerSurvey(Guid id)
        {
            AnswerSurvey answerSurvey = db.AnswerSurveys.Find(id);
            if (answerSurvey == null)
            {
                return NotFound();
            }

            return Ok(answerSurvey);
        }

        // PUT: api/AnswerSurveys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnswerSurvey(Guid id, AnswerSurvey answerSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answerSurvey.ID)
            {
                return BadRequest();
            }

            db.Entry(answerSurvey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerSurveyExists(id))
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

        // POST: api/AnswerSurveys
        [ResponseType(typeof(AnswerSurvey))]
        public IHttpActionResult PostAnswerSurvey(AnswerSurvey answerSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnswerSurveys.Add(answerSurvey);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnswerSurveyExists(answerSurvey.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = answerSurvey.ID }, answerSurvey);
        }

        // DELETE: api/AnswerSurveys/5
        [ResponseType(typeof(AnswerSurvey))]
        public IHttpActionResult DeleteAnswerSurvey(Guid id)
        {
            AnswerSurvey answerSurvey = db.AnswerSurveys.Find(id);
            if (answerSurvey == null)
            {
                return NotFound();
            }

            db.AnswerSurveys.Remove(answerSurvey);
            db.SaveChanges();

            return Ok(answerSurvey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnswerSurveyExists(Guid id)
        {
            return db.AnswerSurveys.Count(e => e.ID == id) > 0;
        }
    }
}