using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class Role : BaseDataObject
    {
        public string RoleName { get; set; }

        public string Description { get; set; }

        public Role()
        {
        }
    }
}