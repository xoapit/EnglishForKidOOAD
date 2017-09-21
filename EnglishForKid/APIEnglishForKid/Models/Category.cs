using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class Category : BaseDataObject
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public Category()
        {
            Lessons = new List<Lesson>();
        }
    }
}