using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("Feedback")]
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