using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.Data.Entity;

namespace EnglishForKidAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser 
    {
        public bool Status { get; set; }

        public DateTime CreateAt { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public DateTime Birthday { get; set; }

        public bool Gender { get; set; }

        public string Address { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}