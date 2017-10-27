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
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Routing;
using EnglishForKidAPI.Helper;

namespace EnglishForKidAPI.Controllers
{
    public class FeedbackReplyHistoriesController : BaseApiController
    {
        // GET: api/FeedbackReplyHistories
        public IQueryable<FeedbackReplyHistory> GetFeedbackReplyHistorys()
        {
            return db.FeedbackReplyHistories;
        }

        // GET: api/FeedbackReplyHistories/Feedbacks/5
        [Route("api/FeedbackReplyHistories/Feedbacks/{id}")]
        public List<FeedbackReplyHistory> GetFeedbackReplyHistorysByFeedbackID(Guid id)
        {
            List<FeedbackReplyHistory> feedbackReplyHistories = db.FeedbackReplyHistories.Where(x=>x.FeedbackID==id).ToList();
            return feedbackReplyHistories;
        }

        // GET: api/FeedbackReplyHistories/5
        [ResponseType(typeof(FeedbackReplyHistory))]
        public IHttpActionResult GetFeedbackReplyHistory(Guid id)
        {
            FeedbackReplyHistory feedbackReplyHistory = db.FeedbackReplyHistories.Find(id);
            if (feedbackReplyHistory == null)
            {
                return NotFound();
            }

            return Ok(feedbackReplyHistory);
        }

        // PUT: api/FeedbackReplyHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeedbackReplyHistory(Guid id, FeedbackReplyHistory feedbackReplyHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedbackReplyHistory.ID)
            {
                return BadRequest();
            }

            db.Entry(feedbackReplyHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackReplyHistoryExists(id))
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

        // POST: api/FeedbackReplyHistories
        [ResponseType(typeof(FeedbackReplyHistory))]
        public IHttpActionResult PostFeedbackReplyHistory(FeedbackReplyHistory feedbackReplyHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FeedbackReplyHistories.Add(feedbackReplyHistory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FeedbackReplyHistoryExists(feedbackReplyHistory.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            Feedback feedback = db.Feedbacks.Find(feedbackReplyHistory.FeedbackID);
            IdentityMessage identityMessage = new IdentityMessage()
            {
                Destination = feedback.Email,
                Body = feedbackReplyHistory.Content,
                Subject = feedbackReplyHistory.Subject
            };

            EmailHelper emailHelper = new EmailHelper();
            emailHelper.SendEmail(identityMessage);
            return CreatedAtRoute("DefaultApi", new { id = feedbackReplyHistory.ID }, feedbackReplyHistory);
        }

        // DELETE: api/FeedbackReplyHistories/5
        [ResponseType(typeof(FeedbackReplyHistory))]
        public IHttpActionResult DeleteFeedbackReplyHistory(Guid id)
        {
            FeedbackReplyHistory feedbackReplyHistory = db.FeedbackReplyHistories.Find(id);
            if (feedbackReplyHistory == null)
            {
                return NotFound();
            }

            db.FeedbackReplyHistories.Remove(feedbackReplyHistory);
            db.SaveChanges();

            return Ok(feedbackReplyHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedbackReplyHistoryExists(Guid id)
        {
            return db.FeedbackReplyHistories.Count(e => e.ID == id) > 0;
        }
    }
}