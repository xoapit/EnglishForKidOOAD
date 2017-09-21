using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class Rate : BaseDataObject
    {
        public int Level { get; set; }
        public Guid AccountID { get; set; }
        public Guid LessonID { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual Account Account { get; set; }
        public virtual Lesson Lesson { get; set; }

        public Rate()
        {
            CreateAt = DateTime.Now;
        }
    }
}