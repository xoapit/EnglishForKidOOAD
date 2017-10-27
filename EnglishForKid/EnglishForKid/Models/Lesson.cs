using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class Lesson : BaseDataObject
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Guid CategoryID { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Discussion { get; set; }

        [Required]
        public string Exercise { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        public string Tag { get; set; }

        [Required]
        public Guid LevelID { get; set; }

        [Required]
        public string ApplicationUserID { get; set; }

        [Required]
        public virtual Level Level { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        
        public Lesson()
        {
            CreateAt = DateTime.Now;
        }

    }
}