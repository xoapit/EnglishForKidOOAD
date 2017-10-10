using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    public class Level : BaseDataObject
    {
        public int Value { get; set; }
        
        public string Description { get; set; }

    }
}