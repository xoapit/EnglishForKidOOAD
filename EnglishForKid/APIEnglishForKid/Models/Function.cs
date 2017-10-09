using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class Function: BaseDataObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid RoleID { get; set; }
        public Guid BusinessID { get; set; }
        
        public virtual Role Role { get; set; }
        public virtual Business Business { get; set; }
    }
}