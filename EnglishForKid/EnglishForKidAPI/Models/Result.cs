using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("Result")]
    public class Result : BaseDataObject
    {
        public Guid QuestionSurveyID { get; set; }
        public string Answer { get; set; }
        public DateTime CreateAt { get; set; }
        
        public virtual QuestionSurvey QuestionSurvey { get; set; }

        public Result()
        {
            CreateAt = DateTime.Now;
        }
    }
}