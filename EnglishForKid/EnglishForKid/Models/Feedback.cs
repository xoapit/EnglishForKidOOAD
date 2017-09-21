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
        public Guid AccountID { get; set; }

        public virtual Account Account { get; set; }
        public Feedback()
        {
            CreateAt = DateTime.Now;
        }
    }
}