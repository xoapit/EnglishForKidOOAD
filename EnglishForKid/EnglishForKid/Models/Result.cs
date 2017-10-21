using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class Result : BaseDataObject
    {
        public Guid QuestionSurveyID { get; set; }
        public string Answer { get; set; }
        public string ApplicationUserID { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual QuestionSurvey QuestionSurvey { get; set; }

        public Result()
        {
            CreateAt = DateTime.Now;
        }
    }
}