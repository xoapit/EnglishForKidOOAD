using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishForKid.Models
{
    public class Lesson : BaseDataObject
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Category Name")]
        public Guid CategoryID { get; set; }

        [Required]
        [Display(Name ="Url Image")]
        public string Image { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name ="Content")]
        public string Content { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name ="Discussion")]
        public string Discussion { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name ="Exercise")]
        public string Exercise { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name ="Answer")]
        public string Answer { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateAt { get; set; }

        public string Tag { get; set; }

        [Display(Name ="Level")]
        public Guid LevelID { get; set; }

        [Required]
        public string ApplicationUserID { get; set; }

        public virtual Level Level { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Category Category { get; set; }

        //public bool Status { get; set; }

        //public String GetStatus() => Status ? "Active" : "InActive";
        
        public Lesson()
        {
            CreateAt = DateTime.Now;
        }

    }
}