namespace APIEnglishForKid.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using APIEnglishForKid.App_Start;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class EnglishDatabase : IdentityDbContext<ApplicationUser>
    {
        public EnglishDatabase()
            : base("EnglishForKid", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new CreateEnglishDatabaseIfNotExists());
        }
        public static EnglishDatabase Create()
        {
            return new EnglishDatabase();
        }

        private class CreateEnglishDatabaseIfNotExists : CreateDatabaseIfNotExists<EnglishDatabase>
        {
            protected override void Seed(EnglishDatabase context)
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
                base.Seed(context);
            }
        }

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
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id).ToTable("Role");
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<IdentityUserRole>()
            .HasKey(r => new { r.UserId, r.RoleId })
            .ToTable("AspNetUserRoles");
            

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("AspNetUserLogins");
        }
    }
}
