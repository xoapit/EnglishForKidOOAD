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
    public class BusinessesController : BaseApiController
    {

        // GET: api/Businesses
        public IQueryable<Business> GetBusinesses()
        {
            return db.Businesses;
        }

        // GET: api/Businesses/5
        [ResponseType(typeof(Business))]
        public IHttpActionResult GetBusiness(Guid id)
        {
            Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return NotFound();
            }

            return Ok(business);
        }

        // PUT: api/Businesses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusiness(Guid id, Business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != business.ID)
            {
                return BadRequest();
            }

            db.Entry(business).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        // POST: api/Businesses
        [ResponseType(typeof(Business))]
        public IHttpActionResult PostBusiness(Business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Businesses.Add(business);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BusinessExists(business.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = business.ID }, business);
        }

        // DELETE: api/Businesses/5
        [ResponseType(typeof(Business))]
        public IHttpActionResult DeleteBusiness(Guid id)
        {
            Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return NotFound();
            }

            db.Businesses.Remove(business);
            db.SaveChanges();

            return Ok(business);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessExists(Guid id)
        {
            return db.Businesses.Count(e => e.ID == id) > 0;
        }
    }
}