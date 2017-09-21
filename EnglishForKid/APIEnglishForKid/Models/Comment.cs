using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class Comment : BaseDataObject
    {
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid LessonID { get; set; }
        public Guid AccountID { get; set; }

        public virtual Account Account { get; set; }
        public virtual Lesson Lesson { get; set; }

        public Comment()
        {
            CreateAt = DateTime.Now;
        }
    }
}