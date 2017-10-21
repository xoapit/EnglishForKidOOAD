using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models.ViewModels
{
    public class BaseQuestionSurveyViewModel : BaseDataObject
    {
        public string Content { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public string GetStatus
        {
            get { return Status ? "Active" : "InActive"; }
        }
    }
}