namespace APIEnglishForKid.Migrations
{
    using APIEnglishForKid.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<APIEnglishForKid.Models.EnglishDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(APIEnglishForKid.Models.EnglishDatabase context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EnglishDatabase()));

            var user = new ApplicationUser()
            {
                UserName = "xoapit",
                Email = "taquyit@gmail.com",
                EmailConfirmed = true,
                FullName = "Quy Ho"
            };

            manager.Create(user, "123456");
        }
    }
}
