using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class Feedback : BaseDataObject
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public Feedback()
        {
            CreateAt = DateTime.Now;
        }
    }
}