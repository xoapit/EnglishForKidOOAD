using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class Authority
    {
        public Guid RoleID { get; set; }
        public Guid AccountID { get; set; }
        
        public virtual Role Role { get; set; }
        public virtual Account Account { get; set; }
    }
}