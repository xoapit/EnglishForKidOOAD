namespace APIEnglishForKid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abcdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 250),
                        Status = c.Boolean(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Profiles", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.AuthenticationTokens",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Token = c.String(),
                        AccountID = c.Guid(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Authorities",
                c => new
                    {
                        RoleID = c.Guid(nullable: false),
                        AccountID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleID, t.AccountID })
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RoleName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FullName = c.String(),
                        Avatar = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Level = c.Int(nullable: false),
                        AccountID = c.Guid(nullable: false),
                        LessonID = c.Guid(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Lessons", t => t.LessonID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.LessonID);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        CategoryID = c.Guid(nullable: false),
                        Image = c.String(),
                        Content = c.String(),
                        Exercise = c.String(),
                        Answer = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        Tag = c.String(),
                        AccountID = c.Guid(nullable: false),
                        Levels_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Levels", t => t.Levels_ID)
                .Index(t => t.CategoryID)
                .Index(t => t.AccountID)
                .Index(t => t.Levels_ID);
            
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
                        AccountID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Lessons", t => t.LessonID, cascadeDelete: true)
                .Index(t => t.LessonID)
                .Index(t => t.AccountID);
            
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
                "dbo.AnswerSurveys",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        QuestionID = c.Guid(nullable: false),
                        Answer = c.String(),
                        QuestionSurvey_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuestionSurveys", t => t.QuestionSurvey_ID)
                .Index(t => t.QuestionSurvey_ID);
            
            CreateTable(
                "dbo.QuestionSurveys",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Content = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        AccountID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        QuestionID = c.Guid(nullable: false),
                        Answer = c.String(),
                        AccountID = c.Guid(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        QuestionSurvey_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.QuestionSurveys", t => t.QuestionSurvey_ID)
                .Index(t => t.AccountID)
                .Index(t => t.QuestionSurvey_ID);
            
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
                        RoleID = c.Guid(nullable: false),
                        BusinessID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Businesses", t => t.BusinessID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.BusinessID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        AccountID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.GrantPermissions",
                c => new
                    {
                        FunctionID = c.Guid(nullable: false),
                        AccountID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.FunctionID, t.AccountID })
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Functions", t => t.FunctionID, cascadeDelete: true)
                .Index(t => t.FunctionID)
                .Index(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GrantPermissions", "FunctionID", "dbo.Functions");
            DropForeignKey("dbo.GrantPermissions", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Feedbacks", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Functions", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Functions", "BusinessID", "dbo.Businesses");
            DropForeignKey("dbo.AnswerSurveys", "QuestionSurvey_ID", "dbo.QuestionSurveys");
            DropForeignKey("dbo.Results", "QuestionSurvey_ID", "dbo.QuestionSurveys");
            DropForeignKey("dbo.Results", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.QuestionSurveys", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Rates", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "Levels_ID", "dbo.Levels");
            DropForeignKey("dbo.Comments", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Comments", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Lessons", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Lessons", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Rates", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "ID", "dbo.Profiles");
            DropForeignKey("dbo.Authorities", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Authorities", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.AuthenticationTokens", "AccountID", "dbo.Accounts");
            DropIndex("dbo.GrantPermissions", new[] { "AccountID" });
            DropIndex("dbo.GrantPermissions", new[] { "FunctionID" });
            DropIndex("dbo.Feedbacks", new[] { "AccountID" });
            DropIndex("dbo.Functions", new[] { "BusinessID" });
            DropIndex("dbo.Functions", new[] { "RoleID" });
            DropIndex("dbo.Results", new[] { "QuestionSurvey_ID" });
            DropIndex("dbo.Results", new[] { "AccountID" });
            DropIndex("dbo.QuestionSurveys", new[] { "AccountID" });
            DropIndex("dbo.AnswerSurveys", new[] { "QuestionSurvey_ID" });
            DropIndex("dbo.Comments", new[] { "AccountID" });
            DropIndex("dbo.Comments", new[] { "LessonID" });
            DropIndex("dbo.Lessons", new[] { "Levels_ID" });
            DropIndex("dbo.Lessons", new[] { "AccountID" });
            DropIndex("dbo.Lessons", new[] { "CategoryID" });
            DropIndex("dbo.Rates", new[] { "LessonID" });
            DropIndex("dbo.Rates", new[] { "AccountID" });
            DropIndex("dbo.Authorities", new[] { "AccountID" });
            DropIndex("dbo.Authorities", new[] { "RoleID" });
            DropIndex("dbo.AuthenticationTokens", new[] { "AccountID" });
            DropIndex("dbo.Accounts", new[] { "UserName" });
            DropIndex("dbo.Accounts", new[] { "ID" });
            DropTable("dbo.GrantPermissions");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Functions");
            DropTable("dbo.Businesses");
            DropTable("dbo.Results");
            DropTable("dbo.QuestionSurveys");
            DropTable("dbo.AnswerSurveys");
            DropTable("dbo.Levels");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Lessons");
            DropTable("dbo.Rates");
            DropTable("dbo.Profiles");
            DropTable("dbo.Roles");
            DropTable("dbo.Authorities");
            DropTable("dbo.AuthenticationTokens");
            DropTable("dbo.Accounts");
        }
    }
}
