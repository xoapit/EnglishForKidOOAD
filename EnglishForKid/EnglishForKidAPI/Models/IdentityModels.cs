using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;

namespace EnglishForKidAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool Status { get; set; }

        public DateTime CreateAt { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public DateTime Birthday { get; set; }

        public bool Gender { get; set; }

        public string Address { get; set; }

        public DateTime UpdateAt { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<QuestionSurvey> QuestionSurveys { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Result> Results { get; set; }

        public DbSet<Business> Businesses { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<GrantPermission> GrantPermissions { get; set; }
        public DbSet<AnswerSurvey> AnswerSurveys { get; set; }
        public DbSet<AuthenticationToken> AuthenticationTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-many 
            modelBuilder.Entity<Lesson>()
                        .HasRequired<ApplicationUser>(s => s.ApplicationUser) // Lesson entity requires Account 
                        .WithMany() // Account entity includes many Lesson entities
                        .HasForeignKey(s => s.ApplicationUserID)
                        .WillCascadeOnDelete(false); //disable scade   

            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);

            modelBuilder.Entity<IdentityUserRole>()
            .HasKey(r => new { r.UserId, r.RoleId });

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
        }

        public ApplicationDbContext()
            : base("EnglishForKids", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<EnglishForKidAPI.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}