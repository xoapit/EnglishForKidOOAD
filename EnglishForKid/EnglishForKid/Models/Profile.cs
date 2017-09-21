using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class Profile : BaseDataObject
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual Account Account { get; set; }

        public Profile()
        {
            CreateAt = DateTime.Now;
        }
    }
}