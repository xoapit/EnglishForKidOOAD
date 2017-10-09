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
    public class LevelsController : ApiController
    {
        private EnglishDatabase db = new EnglishDatabase();

        // GET: api/Levels
        public IQueryable<Level> GetLevels()
        {
            return db.Levels;
        }

        // GET: api/Levels/5
        [ResponseType(typeof(Level))]
        public IHttpActionResult GetLevel(Guid id)
        {
            Level level = db.Levels.Find(id);
            if (level == null)
            {
                return NotFound();
            }

            return Ok(level);
        }

        // PUT: api/Levels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLevel(Guid id, Level level)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != level.ID)
            {
                return BadRequest();
            }

            db.Entry(level).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(id))
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

        // POST: api/Levels
        [ResponseType(typeof(Level))]
        public IHttpActionResult PostLevel(Level level)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Levels.Add(level);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LevelExists(level.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = level.ID }, level);
        }

        // DELETE: api/Levels/5
        [ResponseType(typeof(Level))]
        public IHttpActionResult DeleteLevel(Guid id)
        {
            Level level = db.Levels.Find(id);
            if (level == null)
            {
                return NotFound();
            }

            db.Levels.Remove(level);
            db.SaveChanges();

            return Ok(level);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LevelExists(Guid id)
        {
            return db.Levels.Count(e => e.ID == id) > 0;
        }
    }
}