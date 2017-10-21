using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class QuestionSurvey : BaseDataObject
    {
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Status { get; set; }
        public string ApplicationUserID { get; set; }
        public List<AnswerSurvey> AnswerSurveys { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public QuestionSurvey()
        {
            CreateAt = DateTime.Now;
            Status = false;
            AnswerSurveys = new List<AnswerSurvey>();
        }
    }
}