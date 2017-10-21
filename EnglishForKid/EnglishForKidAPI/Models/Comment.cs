using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("Comment")]
    public class Comment : BaseDataObject
    {
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid LessonID { get; set; }
        public string ApplicationUserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public Comment()
        {
            CreateAt = DateTime.Now;
        }
    }
}