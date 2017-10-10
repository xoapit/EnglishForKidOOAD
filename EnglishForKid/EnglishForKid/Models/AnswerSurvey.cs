using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class AnswerSurvey : BaseDataObject
    {
        public Guid QuestionSurveyID { get; set; }
        public string Answer { get; set; }
               
        public virtual QuestionSurvey QuestionSurvey { get; set; }
    }
}