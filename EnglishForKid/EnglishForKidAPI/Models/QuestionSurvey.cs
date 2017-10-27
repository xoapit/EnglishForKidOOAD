using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models
{
    [Table("QuestionSurvey")]
    public class QuestionSurvey : BaseDataObject
    {
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Status { get; set; }
        public string ApplicationUserID { get; set; }

        public virtual ICollection<AnswerSurvey> AnswerSurveys { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public QuestionSurvey()
        {
            AnswerSurveys = new List<AnswerSurvey>();
            CreateAt = DateTime.Now;
            Status = false;
        }
    }
}