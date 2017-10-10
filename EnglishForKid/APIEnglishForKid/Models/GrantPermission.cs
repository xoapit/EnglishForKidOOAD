using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class GrantPermission
    {
        [Column(Order = 0), Key, ForeignKey("Function")]
        public Guid FunctionID { get; set; }
        [Column(Order = 1), Key, ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }

        public virtual Function Function { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}