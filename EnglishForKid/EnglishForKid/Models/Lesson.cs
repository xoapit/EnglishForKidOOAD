using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class Lesson : BaseDataObject
    {
        public string Title { get; set; }
        public Guid CategoryID { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Discussion { get; set; }
        public string Exercise { get; set; }
        public string Answer { get; set; }
        public DateTime CreateAt { get; set; }
        public string Tag { get; set; }
        public Guid LevelID { get; set; }

        public string ApplicationUserID { get; set; }

        public virtual Level Level { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Category Category { get; set; }

        public Lesson()
        {
            CreateAt = DateTime.Now;
        }

    }
}