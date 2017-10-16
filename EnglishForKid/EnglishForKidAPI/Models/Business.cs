using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("Business")]
    public class Business: BaseDataObject
    {                
        public string Name { get; set; }
        public virtual ICollection<Function> Functions { get; set; }
    }
}