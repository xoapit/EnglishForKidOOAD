using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool Status { get; set; }

        public DateTime CreateAt { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public DateTime Birthday { get; set; }

        public bool Gender { get; set; }

        public string Address { get; set; }

        public DateTime UpdateAt { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser()
        {
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
            Birthday = DateTime.Now;
            Status = true;
            Gender = false;
        }
    }
}