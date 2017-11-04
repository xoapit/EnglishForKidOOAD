using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Models.ViewModels
{
    public class RoleViewModel
    {
        public string UserID { get; set; }

        public bool IsStudent { get; set; }

        public bool IsTeacher { get; set; }

        public bool IsAdmin { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string StudentCheck()
        {
            return IsStudent ? "checked" : "";
        }
        public string TeacherCheck()
        {
            return IsTeacher ? "checked" : "";
        }
        public string AdminCheck()
        {
            return IsAdmin ? "checked" : "";
        }
    }
}