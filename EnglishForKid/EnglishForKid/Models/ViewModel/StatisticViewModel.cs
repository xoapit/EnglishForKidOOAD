using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models.ViewModels
{
    public class StatisticViewModel
    {
        public int NumberOfStudents { get; set; }
        public int NumberOfTeachers { get; set; }
        public int NumberOfAdmins { get; set; }
        public int NumberOfLessons { get; set; }
        public int NumberOfViews { get; set; }
        public int NumberOfFeedbacks { get; set; }
    }
}