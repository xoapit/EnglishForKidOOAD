using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models.ViewModels
{
    public class BaseLessonInfoViewModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public int NumberOfComments { get; set; }
        public string CategoryName { get; set; }
        public float Rate { get; set; }
    }
}