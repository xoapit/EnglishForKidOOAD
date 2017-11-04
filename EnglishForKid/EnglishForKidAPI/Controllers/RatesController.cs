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
    public class RatesController : BaseApiController
    {

        // GET: api/Rates
        [Route("api/Rates")]
        public IQueryable<Rate> GetRates()
        {
            return db.Rates;
        }

        // GET: api/Rates/5
        [Route("api/Rates/")]
        [ResponseType(typeof(Rate))]
        public IHttpActionResult GetRate(Guid id)
        {
            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return NotFound();
            }

            return Ok(rate);
        }

        [Route("api/Rates")]
        public float GetRateOfLesson(Guid lessonID)
        {
            var rates = db.Rates.Where(x => x.LessonID == lessonID).ToList();
            if (rates == null || rates.Count == 0)
            {
                return 0;
            }
            return (float)rates?.Sum(x => x.Level) / rates.Count();
        }

        [Route("api/Rates")]
        public IHttpActionResult GetRateByLessonAndUser(Guid lessonID, string userID)
        {
            var rate = db.Rates.Where(x => x.LessonID == lessonID && x.ApplicationUserID == userID)?.First();
            return Ok(rate);
        }

        // PUT: api/Rates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRate(Guid id, Rate rate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rate.ID)
            {
                return BadRequest();
            }

            db.Entry(rate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateExists(id))
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

        // POST: api/Rates
        [Route("api/Rates")]
        [ResponseType(typeof(Rate))]
        public IHttpActionResult PostRate(Rate rate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (db.Rates.Find(rate.ID) == null)
            {
                db.Rates.Add(rate);
            }
            else
            {
                Rate tempRate = db.Rates.Find(rate.ID);
                tempRate.Level = rate.Level;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RateExists(rate.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Ok(rate);
        }

        // DELETE: api/Rates/5
        [ResponseType(typeof(Rate))]
        public IHttpActionResult DeleteRate(Guid id)
        {
            Rate rate = db.Rates.Find(id);
            if (rate == null)
            {
                return NotFound();
            }

            db.Rates.Remove(rate);
            db.SaveChanges();

            return Ok(rate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RateExists(Guid id)
        {
            return db.Rates.Count(e => e.ID == id) > 0;
        }
    }
}