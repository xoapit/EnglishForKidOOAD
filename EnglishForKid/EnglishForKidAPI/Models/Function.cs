using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("Function")]
    public class Function: BaseDataObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IdentityRoleID { get; set; }
        public Guid BusinessID { get; set; }
        
        public virtual Business Business { get; set; }
        public virtual IdentityRole IdentityRole { get; set; }
    }
}