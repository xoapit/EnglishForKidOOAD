using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class Authority
    {
        [Column(Order = 0), Key, ForeignKey("Role")]
        public Guid RoleID { get; set; }
        [Column(Order = 1), Key, ForeignKey("Account")]
        public Guid AccountID { get; set; }
        
        public virtual Role Role { get; set; }
        public virtual Account Account { get; set; }
    }
}