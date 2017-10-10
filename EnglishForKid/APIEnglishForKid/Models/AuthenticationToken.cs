using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class AuthenticationToken : BaseDataObject
    {
        public string Token { get; set; }
        public string ApplicationUserID { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public AuthenticationToken()
        {
            CreateAt = DateTime.Now;
        }
    }
}