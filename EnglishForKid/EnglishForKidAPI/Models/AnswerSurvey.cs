using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("AnswerSurvey")]
    public class AnswerSurvey : BaseDataObject
    {
        public Guid QuestionSurveyID { get; set; }
        public string Answer { get; set; }
               
        public virtual QuestionSurvey QuestionSurvey { get; set; }
    }
}