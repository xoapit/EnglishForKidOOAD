namespace EnglishForKidAPI.Migrations
{
    using EnglishForKidAPI.Constants;
    using EnglishForKidAPI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EnglishForKidAPI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // InitUsers(context);
            // InitCategories(context);
            //   InitBusinessesAndFunctions(context);
            InitFeedbacks(context);
            //  InitLevels(context);
            //   InitLessons(context);
            //InitCommets(context);
            //InitQuestionSurveys(context);
            //InitRates(context);
            //InitResults(context);
        }

        private void InitCommets(ApplicationDbContext context)
        {
            context.Comments.Add(new Comment
            {
                ID = Guid.NewGuid(),
                Content = "Not bad",
                CreateAt = DateTime.Now,
                LessonID = context.Lessons.First().ID,
                ApplicationUserID = context.Users.First().Id
            });

            context.Comments.Add(new Comment
            {
                ID = Guid.NewGuid(),
                Content = "Not bad",
                CreateAt = DateTime.Now,
                LessonID = context.Lessons.First().ID,
                ApplicationUserID = context.Users.First().Id
            });

            context.Comments.Add(new Comment
            {
                ID = Guid.NewGuid(),
                Content = "Not bad",
                CreateAt = DateTime.Now,
                LessonID = context.Lessons.First().ID,
                ApplicationUserID = context.Users.First().Id
            });

            context.SaveChanges();
        }

        private void InitQuestionSurveys(ApplicationDbContext context)
        {
            context.QuestionSurveys.Add(new QuestionSurvey
            {
                ID = Guid.NewGuid(),
                Content = "What do you think about us?",
                CreateAt = DateTime.Now,
                Status = true,
                ApplicationUserID = context.Users.First().Id
            });

            context.QuestionSurveys.Add(new QuestionSurvey
            {
                ID = Guid.NewGuid(),
                Content = "What do you think about us?",
                CreateAt = DateTime.Now,
                Status = true,
                ApplicationUserID = context.Users.First().Id
            });

            context.QuestionSurveys.Add(new QuestionSurvey
            {
                ID = Guid.NewGuid(),
                Content = "What do you think about us?",
                CreateAt = DateTime.Now,
                Status = true,
                ApplicationUserID = context.Users.First().Id
            });

            context.SaveChanges();
        }

        private void InitRates(ApplicationDbContext context)
        {
            context.Rates.Add(new Rate
            {
                ID = Guid.NewGuid(),
                LessonID = context.Lessons.First().ID,
                ApplicationUserID = context.Users.First().Id,
                CreateAt = DateTime.Now
            });

            context.SaveChanges();
        }

        private void InitResults(ApplicationDbContext context)
        {
            context.Results.Add(new Result
            {
                ID = Guid.NewGuid(),
                QuestionSurveyID = context.QuestionSurveys.First().ID,
                Answer = "Gi vay troi",
                ApplicationUserID = context.Users.First().Id,
                CreateAt = DateTime.Now
            });

            context.SaveChanges();
        }

        private void InitLevels(ApplicationDbContext context)
        {
            context.Levels.RemoveRange(context.Levels.ToList());

            context.Levels.Add(new Level
            {
                ID = Guid.NewGuid(),
                Value = 1,
                Description = "For Grade 1,2,3"
            });

            context.Levels.Add(new Level
            {
                ID = Guid.NewGuid(),
                Value = 2,
                Description = "For Grade 4,5"
            });

            context.Levels.Add(new Level
            {
                ID = Guid.NewGuid(),
                Value = 3,
                Description = "For Grade 6,7"
            });

            context.SaveChanges();
        }

        private void InitLessons(ApplicationDbContext context)
        {
            context.Lessons.RemoveRange(context.Lessons.ToList());

            context.Lessons.Add(
                new Lesson
                {
                    ID = Guid.NewGuid(),
                    Title = "How to kill some people?",
                    CategoryID = context.Categories.First().ID,
                    LevelID = context.Levels.First().ID,
                    ApplicationUserID = context.Users.First().Id
                }
            );

            context.Lessons.Add(
               new Lesson
               {
                   ID = Guid.NewGuid(),
                   Title = "Learn vocabulary fast and remember long time",
                   CategoryID = context.Categories.First().ID,
                   LevelID = context.Levels.First().ID,
                   ApplicationUserID = context.Users.First().Id
               }
           );

            context.Lessons.Add(
                new Lesson
                {
                    ID = Guid.NewGuid(),
                    Title = "Love English",
                    CategoryID = context.Categories.First().ID,
                    LevelID = context.Levels.First().ID,
                    ApplicationUserID = context.Users.First().Id
                }
            );

            context.SaveChanges();
        }

        private void InitFeedbacks(ApplicationDbContext context)
        {
            context.Feedbacks.Add(new Feedback
            {
                ID = Guid.NewGuid(),
                Title = "Tin was blocked!",
                Content = "Hello, what's up?",
                CreateAt = DateTime.Now,
                Email = "taquyit@gmail.com"
            });

            context.Feedbacks.Add(new Feedback
            {
                ID = Guid.NewGuid(),
                Title = "Tin was blocked!",
                Content = "Hello, what's up?",
                CreateAt = DateTime.Now,
                Email = "huuquan95@gmail.com"
            });

            context.Feedbacks.Add(new Feedback
            {
                ID = Guid.NewGuid(),
                Title = "Tin was blocked!",
                Content = "Hello, what's up?",
                CreateAt = DateTime.Now,
                Email = "quoctin95@gmail.com"
            });
        }

        private void InitBusinessesAndFunctions(ApplicationDbContext context)
        {
            context.Functions.RemoveRange(context.Functions.ToList());
            context.Businesses.RemoveRange(context.Businesses.ToList());

            ReflectionController reflection = new ReflectionController();
            foreach (var controller in reflection.GetControllers())
            {
                Business bussiness = new Business
                {
                    ID = Guid.NewGuid(),
                    Name = controller.Name
                };

                context.Businesses.Add(bussiness);

                foreach (var action in reflection.GetActions(controller))
                {
                    context.Functions.Add(new Function
                    {
                        ID = Guid.NewGuid(),
                        Name = action,
                        BusinessID = bussiness.ID,
                        IdentityRoleID = context.Roles.Where(r => r.Name == "Admin").First().Id
                    });
                }
            }
        }
        
        //private void InitBusinessesAndFunctions(ApplicationDbContext context)
        //{
        //    context.Functions.RemoveRange(context.Functions.ToList());
        //    context.Businesses.RemoveRange(context.Businesses.ToList());

        //    ReflectionController reflection = new ReflectionController();
        //    foreach (var controller in reflection.GetControllers())
        //    {
        //        Business bussiness = new Business
        //        {
        //            ID = Guid.NewGuid(),
        //            Name = controller.Name
        //        };

        //        context.Businesses.Add(bussiness);

        //        foreach (var action in reflection.GetActions(controller))
        //        {
        //            context.Functions.Add(new Function
        //            {
        //                ID = Guid.NewGuid(),
        //                Name = action,
        //                BusinessID = bussiness.ID,
        //                IdentityRoleID = context.Roles.Where(r => r.Name == "Admin").First().Id
        //            });
        //        }
        //    }
        //}

        private void InitUsers(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole(ApplicationConfig.AdminRole));
            roleManager.Create(new IdentityRole(ApplicationConfig.TeacherRole));
            roleManager.Create(new IdentityRole(ApplicationConfig.StudentRole));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user1 = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "stu",
                Email = "student@gmail.com",
                EmailConfirmed = true,
                FullName = "Dat Nguyen",
                Birthday = DateTime.Now,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Gender = true,
                Status = true
            };

            var user2 = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "teacher",
                Email = "taquyit@gmail.com",
                EmailConfirmed = true,
                FullName = "Hien Nguyen",
                Birthday = DateTime.Now,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Gender = false,
                Status = true
            };

            var user3 = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                Email = "taquyit@gmail.com",
                EmailConfirmed = true,
                FullName = "Quy Ho",
                Birthday = DateTime.Now,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Gender = true,
                Status = true
            };

            userManager.Create(user1, "123456");
            userManager.Create(user2, "123456");
            userManager.Create(user3, "123456");
            userManager.AddToRole(user1.Id, ApplicationConfig.StudentRole);
            userManager.AddToRole(user2.Id, ApplicationConfig.TeacherRole);
            userManager.AddToRole(user3.Id, ApplicationConfig.AdminRole);
        }
        private void InitCategories(ApplicationDbContext context)
        {
            context.Categories.RemoveRange(context.Categories.ToList());

            context.Categories.Add(new Category()
            {
                ID = Guid.NewGuid(),
                Name = ApplicationConfig.ListentCategory
            });
            context.Categories.Add(new Category()
            {
                ID = Guid.NewGuid(),
                Name = ApplicationConfig.SpeakingCategory
            });
            context.Categories.Add(new Category()
            {
                ID = Guid.NewGuid(),
                Name = ApplicationConfig.SpeakingCategory
            });
            context.Categories.Add(new Category()
            {
                ID = Guid.NewGuid(),
                Name = ApplicationConfig.WritingCategory
            });
            context.Categories.Add(new Category()
            {
                ID = Guid.NewGuid(),
                Name = ApplicationConfig.VocabularyCategory
            });
            context.Categories.Add(new Category()
            {
                ID = Guid.NewGuid(),
                Name = ApplicationConfig.WatchingCategory
            });
            context.Categories.Add(new Category()
            {
                ID = Guid.NewGuid(),
                Name = ApplicationConfig.SpellCategory
            });
            context.Categories.Add(new Category()
            {
                ID = Guid.NewGuid(),
                Name = ApplicationConfig.GrammarCategory
            });
            context.SaveChanges();
        }
    }
}
