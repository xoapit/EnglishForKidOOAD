using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class Lesson : BaseDataObject
    {
        public string Title { get; set; }
        public Guid CategoryID { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Exercise { get; set; }
        public string Answer { get; set; }
        public DateTime CreateAt { get; set; }
        public string Tag { get; set; }

        public Guid AccountID { get; set; }

        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }

        public Lesson()
        {
            Comments = new List<Comment>();
            Rates = new List<Rate>();
            CreateAt = DateTime.Now;
        }

    }
}