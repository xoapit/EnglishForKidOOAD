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
    public class QuestionSurveysController : BaseApiController
    {
        // GET: api/QuestionSurveys
        [Route("api/QuestionSurveys")]
        public IEnumerable<QuestionSurvey> GetQuestionSurveys()
        {
            return db.QuestionSurveys;
        }

        [Route("api/QuestionSurveys/base")]
        public List<BaseQuestionSurveyViewModel> GetBaseQuestionSurveys()
        {
            List<BaseQuestionSurveyViewModel> baseQuestionSurveys = new List<BaseQuestionSurveyViewModel>();
            foreach (var questionSurvey in db.QuestionSurveys)
            {
                BaseQuestionSurveyViewModel baseQuestionSurvey = ModelFactory.GetQuestionSurveyViewModel(questionSurvey);
                baseQuestionSurveys.Add(baseQuestionSurvey);
            }
            return baseQuestionSurveys;
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

        [ResponseType(typeof(QuestionSurvey))]
        [Route("api/getActiveQuestion")]
        public IHttpActionResult GetActiveQuestion()
        {
            QuestionSurvey questionSurvey = db.QuestionSurveys.FirstOrDefault(p => p.Status == true);

            if (questionSurvey == null)
            {
                return NotFound();
            }

            return Ok(questionSurvey);
        }

        [HttpPost]
        [ResponseType(typeof(ActualSurveyResult))]
        [Route("api/QuestionSurvey/actualResult")]
        public IHttpActionResult GetResultOfSurvey()
        {
            ActualSurveyResult actualSurveyResult = new ActualSurveyResult();
            QuestionSurvey questionSurvey = db.QuestionSurveys.FirstOrDefault(p => p.Status == true);
            foreach(var item in questionSurvey.AnswerSurveys)
            {
                int count= db.Results.Where(x => x.Answer == item.ID.ToString()).Count();
                actualSurveyResult.Results.Add(count);
            }
            return Ok(actualSurveyResult);
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

            foreach (var answerSurvey in questionSurvey.AnswerSurveys)
            {
                db.Entry(answerSurvey).State = EntityState.Modified;
            }

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

            return Ok();
        }

        // POST: api/QuestionSurveys
        [ResponseType(typeof(QuestionSurvey))]
        [Route("api/activeQuestion")]
        public IHttpActionResult PostActiveQuestion(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            QuestionSurvey questionSurvey = db.QuestionSurveys.FirstOrDefault(p => p.ID == id);
            if (questionSurvey == null)
            {
                return NotFound();
            }

            questionSurvey.Status = !questionSurvey.Status;

            db.Entry(questionSurvey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
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

            return Ok();

        }


        // POST: api/QuestionSurveys
        [ResponseType(typeof(QuestionSurvey))]
        [Route("api/QuestionSurveys")]
        public IHttpActionResult PostQuestionSurvey(QuestionSurvey questionSurvey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<AnswerSurvey> answers = questionSurvey.AnswerSurveys.ToList();
            questionSurvey.AnswerSurveys = null;

            db.QuestionSurveys.Add(questionSurvey);

            foreach (var answer in answers)
            {
                db.AnswerSurveys.Add(new AnswerSurvey
                {
                    ID = Guid.NewGuid(),
                    Answer = answer.Answer,
                    QuestionSurveyID = questionSurvey.ID
                });
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
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

            return Ok();
        }

        // DELETE: api/QuestionSurveys/5
        [Route("api/QuestionSurveys/{id}")]
        [ResponseType(typeof(QuestionSurvey))]
        public IHttpActionResult DeleteQuestionSurvey(Guid id)
        {
            QuestionSurvey questionSurvey = db.QuestionSurveys.Find(id);
            if (questionSurvey == null)
            {
                return NotFound();
            }

            var answers = db.AnswerSurveys.Where(x => x.QuestionSurveyID == questionSurvey.ID);
            db.AnswerSurveys.RemoveRange(answers);
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