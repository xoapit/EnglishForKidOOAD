using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("Rate")]
    public class Rate : BaseDataObject
    {
        public float Level { get; set; }
        public string ApplicationUserID { get; set; }
        public Guid LessonID { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public Rate()
        {
            CreateAt = DateTime.Now;
        }
    }
}