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
    public class AuthenticationTokensController : BaseApiController
    {

        // GET: api/AuthenticationTokens
        public IQueryable<AuthenticationToken> GetAuthenticationTokens()
        {
            return db.AuthenticationTokens;
        }

        // GET: api/AuthenticationTokens/5
        [ResponseType(typeof(AuthenticationToken))]
        public IHttpActionResult GetAuthenticationToken(Guid id)
        {
            AuthenticationToken authenticationToken = db.AuthenticationTokens.Find(id);
            if (authenticationToken == null)
            {
                return NotFound();
            }

            return Ok(authenticationToken);
        }

        // PUT: api/AuthenticationTokens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthenticationToken(Guid id, AuthenticationToken authenticationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authenticationToken.ID)
            {
                return BadRequest();
            }

            db.Entry(authenticationToken).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthenticationTokenExists(id))
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

        // POST: api/AuthenticationTokens
        [ResponseType(typeof(AuthenticationToken))]
        public IHttpActionResult PostAuthenticationToken(AuthenticationToken authenticationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AuthenticationTokens.Add(authenticationToken);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AuthenticationTokenExists(authenticationToken.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = authenticationToken.ID }, authenticationToken);
        }

        // DELETE: api/AuthenticationTokens/5
        [ResponseType(typeof(AuthenticationToken))]
        public IHttpActionResult DeleteAuthenticationToken(Guid id)
        {
            AuthenticationToken authenticationToken = db.AuthenticationTokens.Find(id);
            if (authenticationToken == null)
            {
                return NotFound();
            }

            db.AuthenticationTokens.Remove(authenticationToken);
            db.SaveChanges();

            return Ok(authenticationToken);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthenticationTokenExists(Guid id)
        {
            return db.AuthenticationTokens.Count(e => e.ID == id) > 0;
        }
    }
}