using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models
{
    public class Account : BaseDataObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordToken { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Authority> Authorities { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<QuestionSurvey> QuestionSurveys { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<AuthenticationToken> AuthenticationTokens { get; set; }

        public Account()
        {
            Rates = new List<Rate>();
            Authorities = new List<Authority>();
            Results = new List<Result>();
            QuestionSurveys = new List<QuestionSurvey>();
            Lessons = new List<Lesson>();
            Comments = new List<Comment>();
            Feedbacks = new List<Feedback>();
            AuthenticationTokens = new List<AuthenticationToken>();

            CreateAt = DateTime.Now;
            Status = true;
        }
    }
}