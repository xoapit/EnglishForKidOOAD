using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    public class View : BaseDataObject
    {
        public int PageView { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public int Day { get; set; }
    }
}