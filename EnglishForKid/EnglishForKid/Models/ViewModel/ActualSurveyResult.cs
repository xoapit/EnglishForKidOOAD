using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models.ViewModel
{
    public class ActualSurveyResult
    {
        public List<int> Results {get;set;}

        public ActualSurveyResult()
        {
            Results = new List<int>();
        }
    }
}