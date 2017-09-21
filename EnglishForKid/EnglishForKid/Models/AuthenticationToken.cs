using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class AuthenticationToken : BaseDataObject
    {
        public string Token { get; set; }
        public Guid AccountID { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual Account Account { get; set; }

        public AuthenticationToken()
        {
            CreateAt = DateTime.Now;
        }
    }
}