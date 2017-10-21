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
        public IQueryable<Rate> GetRates()
        {
            return db.Rates;
        }

        // GET: api/Rates/5
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
        [ResponseType(typeof(Rate))]
        public IHttpActionResult PostRate(Rate rate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rates.Add(rate);

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

            return CreatedAtRoute("DefaultApi", new { id = rate.ID }, rate);
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