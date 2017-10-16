using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("Level")]
    public class Level : BaseDataObject
    {
        public int Value { get; set; }
        
        public string Description { get; set; }

    }
}