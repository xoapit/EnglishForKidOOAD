namespace EnglishForKidAPI.Migrations
{
    using EnglishForKidAPI.Constants;
    using EnglishForKidAPI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
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
          //  InitCategories(context);
        }

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
