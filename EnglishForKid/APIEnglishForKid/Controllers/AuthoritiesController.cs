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
    public class AuthoritiesController : ApiController
    {
        private EnglishDatabase db = new EnglishDatabase();

        // GET: api/Authorities
        public IQueryable<Authority> GetAuthorities()
        {
            return db.Authorities;
        }

        // GET: api/Authorities/5
        [ResponseType(typeof(Authority))]
        public IHttpActionResult GetAuthority(Guid id)
        {
            Authority authority = db.Authorities.Find(id);
            if (authority == null)
            {
                return NotFound();
            }

            return Ok(authority);
        }

        // PUT: api/Authorities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthority(Guid id, Authority authority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authority.RoleID)
            {
                return BadRequest();
            }

            db.Entry(authority).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorityExists(id))
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

        // POST: api/Authorities
        [ResponseType(typeof(Authority))]
        public IHttpActionResult PostAuthority(Authority authority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authorities.Add(authority);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AuthorityExists(authority.RoleID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = authority.RoleID }, authority);
        }

        // DELETE: api/Authorities/5
        [ResponseType(typeof(Authority))]
        public IHttpActionResult DeleteAuthority(Guid id)
        {
            Authority authority = db.Authorities.Find(id);
            if (authority == null)
            {
                return NotFound();
            }

            db.Authorities.Remove(authority);
            db.SaveChanges();

            return Ok(authority);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorityExists(Guid id)
        {
            return db.Authorities.Count(e => e.RoleID == id) > 0;
        }
    }
}