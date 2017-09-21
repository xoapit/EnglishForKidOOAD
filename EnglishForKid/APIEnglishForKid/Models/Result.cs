using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIEnglishForKid.Models
{
    public class Result : BaseDataObject
    {
        public Guid QuestionID { get; set; }
        public string Answer { get; set; }
        public Guid AccountID { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual Account Account { get; set; }
        public virtual QuestionSurvey QuestionSurvey { get; set; }

        public Result()
        {
            CreateAt = DateTime.Now;
        }
    }
}