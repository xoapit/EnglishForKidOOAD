using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class QuestionSurvey:BaseDataObject
    {
        public string Content { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Status { get; set; }
        public Guid AccountID { get; set; }

        public virtual ICollection<Result> Results { get; set; }
        public virtual Account Account { get; set; }

        public QuestionSurvey()
        {
            Results = new List<Result>();
            CreateAt = DateTime.Now;
        }
    }
}