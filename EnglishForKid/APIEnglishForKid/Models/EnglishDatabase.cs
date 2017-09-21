namespace APIEnglishForKid.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using APIEnglishForKid.App_Start;

    public partial class EnglishDatabase : DbContext
    {
        public EnglishDatabase()
            : base("name=EnglishForKid")
        {
            Database.SetInitializer(new CreateEnglishDatabaseIfNotExists());
        }

        private class CreateEnglishDatabaseIfNotExists: CreateDatabaseIfNotExists<EnglishDatabase>
        {
            protected override void Seed(EnglishDatabase context)
            {
                context.Roles.Add(new Role()
                {
                    ID = Guid.NewGuid(),
                    RoleName = ApplicationConfig.AdminRole
                });
                context.Roles.Add(new Role()
                {
                    ID = Guid.NewGuid(),
                    RoleName = ApplicationConfig.TeacherRole
                });
                context.Roles.Add(new Role()
                {
                    ID = Guid.NewGuid(),
                    RoleName = ApplicationConfig.TeacherRole
                });

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

                Guid accountID = Guid.NewGuid();
                context.Accounts.Add(new Account()
                {
                    ID = accountID,
                    UserName = ApplicationConfig.AdminUserName,
                    Password = ApplicationConfig.AdminPassword,
                    CreateAt = DateTime.Now,
                    Status = true,
                    Profile = new Profile()
                    {
                        ID= Guid.NewGuid(),
                        FullName="Quy Ho",
                        Email="taquyit@gmail.com",
                        Phone="01672734732"
                    }
                });

                Guid AdminRoleID = context.Roles.Where(p => p.RoleName == ApplicationConfig.AdminRole).First().ID;
                context.Authorities.Add(new Authority
                {
                    RoleID=AdminRoleID,
                    AccountID=accountID
                });
                context.SaveChanges();
                base.Seed(context);
            }
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<QuestionSurvey> QuestionSurveys { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(e => e.ID);

            modelBuilder.Entity<Profile>().HasRequired(s => s.Account).WithRequiredPrincipal(s => s.Profile);

            //one-to-many 
            modelBuilder.Entity<Lesson>()
                        .HasRequired<Account>(s => s.Account) // Lesson entity requires Account 
                        .WithMany(s => s.Lessons) // Account entity includes many Lesson entities
                        .HasForeignKey(s => s.AccountID)
                        .WillCascadeOnDelete(false); //disable scade 

        }
    }
}
