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
        [Column(Order = 1), Key, ForeignKey("Account")]
        public Guid AccountID { get; set; }

        public virtual Function Function { get; set; }
        public virtual Account Account { get; set; }
    }
}