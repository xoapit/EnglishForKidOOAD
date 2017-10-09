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
    public class GrantPermissionsController : ApiController
    {
        private EnglishDatabase db = new EnglishDatabase();

        // GET: api/GrantPermissions
        public IQueryable<GrantPermission> GetGrantPermissions()
        {
            return db.GrantPermissions;
        }

        // GET: api/GrantPermissions/5
        [ResponseType(typeof(GrantPermission))]
        public IHttpActionResult GetGrantPermission(Guid id)
        {
            GrantPermission grantPermission = db.GrantPermissions.Find(id);
            if (grantPermission == null)
            {
                return NotFound();
            }

            return Ok(grantPermission);
        }

        // PUT: api/GrantPermissions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrantPermission(Guid id, GrantPermission grantPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grantPermission.FunctionID)
            {
                return BadRequest();
            }

            db.Entry(grantPermission).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrantPermissionExists(id))
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

        // POST: api/GrantPermissions
        [ResponseType(typeof(GrantPermission))]
        public IHttpActionResult PostGrantPermission(GrantPermission grantPermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GrantPermissions.Add(grantPermission);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GrantPermissionExists(grantPermission.FunctionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = grantPermission.FunctionID }, grantPermission);
        }

        // DELETE: api/GrantPermissions/5
        [ResponseType(typeof(GrantPermission))]
        public IHttpActionResult DeleteGrantPermission(Guid id)
        {
            GrantPermission grantPermission = db.GrantPermissions.Find(id);
            if (grantPermission == null)
            {
                return NotFound();
            }

            db.GrantPermissions.Remove(grantPermission);
            db.SaveChanges();

            return Ok(grantPermission);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GrantPermissionExists(Guid id)
        {
            return db.GrantPermissions.Count(e => e.FunctionID == id) > 0;
        }
    }
}