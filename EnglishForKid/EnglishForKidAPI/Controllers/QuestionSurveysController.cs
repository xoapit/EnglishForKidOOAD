﻿using System;
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
    public class QuestionSurveysController : BaseApiController
    {

        // GET: api/QuestionSurveys
        public List<QuestionSurvey> GetQuestionSurveys()
        {
            return db.QuestionSurveys.ToList();
        }

        // GET: api/QuestionSurveys/5
        [ResponseType(typeof(QuestionSurvey))]
        public IHttpActionResult GetQuestionSurvey(Guid id)
        {
            QuestionSurvey questionSurvey = db.QuestionSurveys.Find(id);

            if (questionSurvey == null)
            {
                return NotFound();
            }

            return Ok(questionSurvey);
        }

        // PUT: api/QuestionSurveys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestionSurvey(Guid id, QuestionSurvey questionSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionSurvey.ID)
            {
                return BadRequest();
            }

            db.Entry(questionSurvey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionSurveyExists(id))
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

        // POST: api/QuestionSurveys
        [ResponseType(typeof(QuestionSurvey))]
        public IHttpActionResult PostQuestionSurvey(QuestionSurvey questionSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionSurveys.Add(questionSurvey);
            db.AnswerSurveys.AddRange(questionSurvey.AnswerSurveys);

            //foreach( var answerSurvey in questionSurvey.AnswerSurveys)
            //{
            //    db.AnswerSurveys.Add(answerSurvey);
            //}

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionSurveyExists(questionSurvey.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = questionSurvey.ID }, questionSurvey);
        }

        // DELETE: api/QuestionSurveys/5
        [ResponseType(typeof(QuestionSurvey))]
        public IHttpActionResult DeleteQuestionSurvey(Guid id)
        {
            QuestionSurvey questionSurvey = db.QuestionSurveys.Find(id);
            if (questionSurvey == null)
            {
                return NotFound();
            }

            db.QuestionSurveys.Remove(questionSurvey);
            db.SaveChanges();

            return Ok(questionSurvey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionSurveyExists(Guid id)
        {
            return db.QuestionSurveys.Count(e => e.ID == id) > 0;
        }
    }
}