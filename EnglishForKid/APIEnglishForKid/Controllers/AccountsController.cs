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
    public class AccountsController : ApiController
    {
        private EnglishDatabase db = new EnglishDatabase();

        // GET: api/Accounts
        public IQueryable<Account> GetAccounts()
        {
            return db.Accounts;
        }

        // GET: api/Accounts/5
        [ResponseType(typeof(Account))]
        public IHttpActionResult GetAccount(Guid id)
        {
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // PUT: api/Accounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccount(Guid id, Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.ID)
            {
                return BadRequest();
            }

            db.Entry(account).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        [ResponseType(typeof(Account))]
        public IHttpActionResult PostAccount(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accounts.Add(account);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountExists(account.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = account.ID }, account);
        }

        // DELETE: api/Accounts/5
        [ResponseType(typeof(Account))]
        public IHttpActionResult DeleteAccount(Guid id)
        {
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }

            db.Accounts.Remove(account);
            db.SaveChanges();

            return Ok(account);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountExists(Guid id)
        {
            return db.Accounts.Count(e => e.ID == id) > 0;
        }
    }
}