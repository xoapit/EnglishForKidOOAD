using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKidAPI.Models
{
    [Table("Lesson")]
    public class Lesson : BaseDataObject
    {
        public string Title { get; set; }
        public Guid CategoryID { get; set; }
        public string Image { get; set; }

        [AllowHtml]
        [MaxLength(3000)]
        public string Content { get; set; }

        [AllowHtml]
        [MaxLength(3000)]
        public string Discussion { get; set; }

        [AllowHtml]
        [MaxLength(3000)]
        public string Exercise { get; set; }

        [AllowHtml]
        [MaxLength(3000)]
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