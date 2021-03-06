﻿using EnglishForKidAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;

namespace EnglishForKidAPI.Models.Factory
{
    public class ModelFactory
    {
        private ApplicationUserManager _AppUserManager;

        public ModelFactory(ApplicationUserManager appUserManager)
        {
            _AppUserManager = appUserManager;
        }

        public UserReturnModel Create(ApplicationUser appUser)
        {
            return new UserReturnModel
            {
                UserName = appUser.UserName,
                Email = appUser.Email,
                Address = appUser.Address,
                Avatar = appUser.Avatar,
                Birthday = appUser.Birthday,
                CreateAt = appUser.CreateAt,
                FullName = appUser.FullName,
                Gender = appUser.Gender,
                Id = appUser.Id,
                Status = appUser.Status,
                PhoneNumber = appUser.PhoneNumber,
                EmailConfirmed = appUser.EmailConfirmed,
                Roles = _AppUserManager.GetRolesAsync(appUser.Id).Result,
                Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result
            };
        }

        public static BaseQuestionSurveyViewModel GetQuestionSurveyViewModel(QuestionSurvey questionSurvey)
        {
            BaseQuestionSurveyViewModel viewModel = new BaseQuestionSurveyViewModel
            {
                ID = questionSurvey.ID,
                Content = questionSurvey.Content,
                CreateAt = questionSurvey.CreateAt,
                Status = questionSurvey.Status
            };
            return viewModel;
        }

        public static BaseLessonInfoViewModel GetBaseLessonInfoViewModel(Lesson lesson)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string des = RemoveHTML(lesson.Content);
            if (des.Length > 150) des = des.Substring(0, 150);
            BaseLessonInfoViewModel viewModel = new BaseLessonInfoViewModel()
            {
                ID = lesson.ID,
                Image = lesson.Image,
                CategoryName = lesson.Category.Name,
                CreateAt = lesson.CreateAt,
                Description = des,
                Title = lesson.Title,
                NumberOfComments = db.Comments.Where(x => x.LessonID == lesson.ID).Count(),
                Rate = db.Rates.Where(x => x.LessonID == lesson.ID).Count() / 5
            };

            return viewModel;
        }

        public static string RemoveHTML(string strHTML)
        {
            return Regex.Replace(strHTML, "<(.|\n)*?>", "");
        }
    }

    public class UserReturnModel
    {
        //public string Url { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public bool Status { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreateAt { get; set; }
        public string Address { get; set; }

        public IList<string> Roles { get; set; }
        public IList<System.Security.Claims.Claim> Claims { get; set; }
    }
}