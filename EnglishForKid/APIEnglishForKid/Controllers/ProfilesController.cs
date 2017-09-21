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
    public class ProfilesController : ApiController
    {
        private UnitOfWork _unitOfWork = UnitOfWork.GetInstance();

        // GET: api/Profiles
        public IEnumerable<Profile> GetProfiles()
        {
            return _unitOfWork.ProfileRepository.GetItems();
        }

        // GET: api/Profiles/5
        [ResponseType(typeof(Profile))]
        public IHttpActionResult GetProfile(Guid id)
        {
            Profile profile = _unitOfWork.ProfileRepository.GetItem(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfile(Guid id, Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.ID)
            {
                return BadRequest();
            }

            return _unitOfWork.ProfileRepository.UpdateItem(profile) ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.BadRequest);
        }

        // POST: api/Profiles
        [ResponseType(typeof(void))]
        public IHttpActionResult PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _unitOfWork.ProfileRepository.AddItem(profile) ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.BadRequest);
        }

        // DELETE: api/Profiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteProfile(Guid id)
        {
            return _unitOfWork.ProfileRepository.DeleteItem(id) ? StatusCode(HttpStatusCode.NoContent) : StatusCode(HttpStatusCode.BadRequest);
        }
    }
}