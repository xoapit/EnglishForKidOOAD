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
using APIEnglishForKid.Repository;

namespace APIEnglishForKid.Controllers
{
    public class Accounts1Controller : ApiController
    {
        private UnitOfWork _unitOfWork = UnitOfWork.GetInstance();

        // GET: api/Accounts
        public IEnumerable<Account> GetAccounts()
        {
            return _unitOfWork.AccountRepository.GetItems();
        }

        // GET: api/Accounts/5
        [ResponseType(typeof(Account))]
        public IHttpActionResult GetAccount(Guid id)
        {
            Account account = _unitOfWork.AccountRepository.GetItem(id);
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

            return _unitOfWork.AccountRepository.UpdateItem(account) ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.BadRequest);
        }

        // POST: api/Accounts
        [ResponseType(typeof(void))]
        public IHttpActionResult PostAccount(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _unitOfWork.AccountRepository.AddItem(account) ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.BadRequest);
        }

        // DELETE: api/Accounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteAccount(Guid id)
        {
            return _unitOfWork.AccountRepository.DeleteItem(id) ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.BadRequest);
        }
    }
}