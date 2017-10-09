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
    public class FunctionsController : ApiController
    {
        private EnglishDatabase db = new EnglishDatabase();

        // GET: api/Functions
        public IQueryable<Function> GetFunctions()
        {
            return db.Functions;
        }

        // GET: api/Functions/5
        [ResponseType(typeof(Function))]
        public IHttpActionResult GetFunction(Guid id)
        {
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return NotFound();
            }

            return Ok(function);
        }

        // PUT: api/Functions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFunction(Guid id, Function function)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != function.ID)
            {
                return BadRequest();
            }

            db.Entry(function).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunctionExists(id))
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

        // POST: api/Functions
        [ResponseType(typeof(Function))]
        public IHttpActionResult PostFunction(Function function)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Functions.Add(function);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FunctionExists(function.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = function.ID }, function);
        }

        // DELETE: api/Functions/5
        [ResponseType(typeof(Function))]
        public IHttpActionResult DeleteFunction(Guid id)
        {
            Function function = db.Functions.Find(id);
            if (function == null)
            {
                return NotFound();
            }

            db.Functions.Remove(function);
            db.SaveChanges();

            return Ok(function);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FunctionExists(Guid id)
        {
            return db.Functions.Count(e => e.ID == id) > 0;
        }
    }
}