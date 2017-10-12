namespace EnglishForKidAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerSurveys",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        QuestionSurveyID = c.Guid(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestionSurveys", t => t.QuestionSurveyID, cascadeDelete: true)
                .Index(t => t.QuestionSurveyID);
            
            CreateTable(
                "dbo.QuestionSurveys",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Content = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.Boolean(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        FullName = c.String(),
                        Avatar = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Address = c.String(),
                        UpdateAt = c.DateTime(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.AuthenticationTokens",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Token = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IdentityRoleID = c.String(maxLength: 128),
                        BusinessID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Businesses", t => t.BusinessID, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRoleID)
                .Index(t => t.IdentityRoleID)
                .Index(t => t.BusinessID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Content = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        LessonID = c.Guid(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Lessons", t => t.LessonID, cascadeDelete: true)
                .Index(t => t.LessonID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        CategoryID = c.Guid(nullable: false),
                        Image = c.String(),
                        Content = c.String(),
                        Discussion = c.String(),
                        Exercise = c.String(),
                        Answer = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        Tag = c.String(),
                        LevelID = c.Guid(nullable: false),
                        ApplicationUserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.LevelID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.LevelID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Value = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.GrantPermissions",
                c => new
                    {
                        FunctionID = c.Guid(nullable: false),
                        ApplicationUserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FunctionID, t.ApplicationUserID })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserID, cascadeDelete: true)
                .ForeignKey("dbo.Functions", t => t.FunctionID, cascadeDelete: true)
                .Index(t => t.FunctionID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Level = c.Int(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                        LessonID = c.Guid(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        QuestionSurveyID = c.Guid(nullable: false),
                        Answer = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.QuestionSurveys", t => t.QuestionSurveyID, cascadeDelete: true)
                .Index(t => t.QuestionSurveyID)
                .Index(t => t.ApplicationUserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "QuestionSurveyID", "dbo.QuestionSurveys");
            DropForeignKey("dbo.Results", "ApplicationUserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Rates", "ApplicationUserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.GrantPermissions", "FunctionID", "dbo.Functions");
            DropForeignKey("dbo.GrantPermissions", "ApplicationUserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Feedbacks", "ApplicationUserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Comments", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "LevelID", "dbo.Levels");
            DropForeignKey("dbo.Lessons", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Lessons", "ApplicationUserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Comments", "ApplicationUserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Functions", "IdentityRoleID", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Functions", "BusinessID", "dbo.Businesses");
            DropForeignKey("dbo.AuthenticationTokens", "ApplicationUserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.AnswerSurveys", "QuestionSurveyID", "dbo.QuestionSurveys");
            DropForeignKey("dbo.QuestionSurveys", "ApplicationUserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.Results", new[] { "ApplicationUserID" });
            DropIndex("dbo.Results", new[] { "QuestionSurveyID" });
            DropIndex("dbo.Rates", new[] { "ApplicationUserID" });
            DropIndex("dbo.GrantPermissions", new[] { "ApplicationUserID" });
            DropIndex("dbo.GrantPermissions", new[] { "FunctionID" });
            DropIndex("dbo.Feedbacks", new[] { "ApplicationUserID" });
            DropIndex("dbo.Lessons", new[] { "ApplicationUserID" });
            DropIndex("dbo.Lessons", new[] { "LevelID" });
            DropIndex("dbo.Lessons", new[] { "CategoryID" });
            DropIndex("dbo.Comments", new[] { "ApplicationUserID" });
            DropIndex("dbo.Comments", new[] { "LessonID" });
            DropIndex("dbo.Functions", new[] { "BusinessID" });
            DropIndex("dbo.Functions", new[] { "IdentityRoleID" });
            DropIndex("dbo.AuthenticationTokens", new[] { "ApplicationUserID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.QuestionSurveys", new[] { "ApplicationUserID" });
            DropIndex("dbo.AnswerSurveys", new[] { "QuestionSurveyID" });
            DropTable("dbo.Results");
            DropTable("dbo.Rates");
            DropTable("dbo.GrantPermissions");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Levels");
            DropTable("dbo.Lessons");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Functions");
            DropTable("dbo.Businesses");
            DropTable("dbo.AuthenticationTokens");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.QuestionSurveys");
            DropTable("dbo.AnswerSurveys");
        }
    }
}
