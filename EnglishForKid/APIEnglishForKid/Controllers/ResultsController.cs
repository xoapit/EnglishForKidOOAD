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
using APIEnglishForKid.Models;

namespace APIEnglishForKid.Controllers
{
    public class ResultsController : ApiController
    {
        private EnglishDatabase db = new EnglishDatabase();

        // GET: api/Results
        public IQueryable<Result> GetResults()
        {
            return db.Results;
        }

        // GET: api/Results/5
        [ResponseType(typeof(Result))]
        public IHttpActionResult GetResult(Guid id)
        {
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Results/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResult(Guid id, Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != result.ID)
            {
                return BadRequest();
            }

            db.Entry(result).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(id))
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

        // POST: api/Results
        [ResponseType(typeof(Result))]
        public IHttpActionResult PostResult(Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Results.Add(result);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ResultExists(result.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = result.ID }, result);
        }

        // DELETE: api/Results/5
        [ResponseType(typeof(Result))]
        public IHttpActionResult DeleteResult(Guid id)
        {
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            db.Results.Remove(result);
            db.SaveChanges();

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResultExists(Guid id)
        {
            return db.Results.Count(e => e.ID == id) > 0;
        }
    }
}