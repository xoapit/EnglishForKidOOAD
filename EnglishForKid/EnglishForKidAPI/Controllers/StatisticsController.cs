using EnglishForKidAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EnglishForKidAPI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using EnglishForKidAPI.Models.Factory;
using EnglishForKidAPI.Constants;

namespace EnglishForKidAPI.Controllers
{
    public class StatisticsController : BaseApiController
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [ResponseType(typeof(StatisticViewModel))]
        public IHttpActionResult GetStatistic()
        {
            int numberOfStudents = 0;
            int numberOfTeachers = 0;
            int numberOfAdmins = 0;
            var users = this.UserManager.Users;
            ModelFactory modelFactory = new ModelFactory(this.UserManager);
            foreach (var user in users)
            {
                UserReturnModel userReturnModel = modelFactory.Create(user);
                if (userReturnModel.Roles.Contains(ApplicationConfig.StudentRole))
                {
                    numberOfStudents++;
                }
                if (userReturnModel.Roles.Contains(ApplicationConfig.TeacherRole))
                {
                    numberOfTeachers++;
                }
                if (userReturnModel.Roles.Contains(ApplicationConfig.AdminRole))
                {
                    numberOfAdmins++;
                }
            }

            int numberOfViews = db.Views.ToList().Sum(x => x.PageView);
            int numberOfLessons = db.Lessons.Count();

            StatisticViewModel statisticViewModel = new StatisticViewModel
            {
                NumberOfAdmins = numberOfAdmins,
                NumberOfStudents = numberOfStudents,
                NumberOfTeachers = numberOfTeachers,
                NumberOfViews = numberOfViews,
                NumberOfLessons = numberOfLessons
            };

            return Ok(statisticViewModel);
        }
    }
}
