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

        [Route("api/Statistics")]
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

        [Route("api/Statistics")]
        [ResponseType(typeof(ChartStatisticViewModel))]
        public IHttpActionResult GetChartData(int days)
        {
            string[] labels = new string[days];
            int[] views = new int[days];
            int[] lessons = new int[days];
            int[] users = new int[days];

            DateTime startDate = DateTime.Now.AddDays(-14);
            for (int i = 0; i < days; i++)
            {
                DateTime currentDate = startDate.AddDays(i);
                labels[i] = currentDate.ToString("dd/MMM");

                int numberOfUsers = db.Users.Where(x => x.CreateAt.Day== currentDate.Day).Count();
                int numberOfLessons = db.Lessons.Where(x => x.CreateAt.Day== currentDate.Day).Count();
                users[i] = numberOfUsers;
                lessons[i] = numberOfLessons;
            }

            ChartStatisticViewModel chartStatistic = new ChartStatisticViewModel
            {
                Labels = labels,
                Lessons = lessons,
                Users = users,
                Views = views
            };

            return Ok(chartStatistic);
        }
    }
}
