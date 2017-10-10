using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class Feedback : BaseDataObject
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public string ApplicationUserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public Feedback()
        {
            CreateAt = DateTime.Now;
        }
    }
}