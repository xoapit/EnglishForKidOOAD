namespace APIEnglishForKid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertiesOfSomeModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rates", "Lesson_ID", "dbo.Lessons");
            DropIndex("dbo.Rates", new[] { "Lesson_ID" });
            RenameColumn(table: "dbo.Rates", name: "Lesson_ID", newName: "LessonID");
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
            
            AddColumn("dbo.Roles", "Description", c => c.String());
            AddColumn("dbo.Categories", "Description", c => c.String());
            AddColumn("dbo.Rates", "CreateAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Profiles", "CreateAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Profiles", "UpdateAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Results", "CreateAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rates", "LessonID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Profiles", "Birthday", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Rates", "LessonID");
            AddForeignKey("dbo.Rates", "LessonID", "dbo.Lessons", "ID", cascadeDelete: true);
            DropColumn("dbo.Accounts", "ApiAuthenication");
            DropColumn("dbo.Lessons", "RateID");
            DropColumn("dbo.Results", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Results", "Content", c => c.String());
            AddColumn("dbo.Lessons", "RateID", c => c.Guid(nullable: false));
            AddColumn("dbo.Accounts", "ApiAuthenication", c => c.String());
            DropForeignKey("dbo.Rates", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.AuthenticationTokens", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Rates", new[] { "LessonID" });
            DropIndex("dbo.AuthenticationTokens", new[] { "AccountID" });
            AlterColumn("dbo.Profiles", "Birthday", c => c.String());
            AlterColumn("dbo.Rates", "LessonID", c => c.Guid());
            DropColumn("dbo.Results", "CreateAt");
            DropColumn("dbo.Profiles", "UpdateAt");
            DropColumn("dbo.Profiles", "CreateAt");
            DropColumn("dbo.Rates", "CreateAt");
            DropColumn("dbo.Categories", "Description");
            DropColumn("dbo.Roles", "Description");
            DropTable("dbo.AuthenticationTokens");
            RenameColumn(table: "dbo.Rates", name: "LessonID", newName: "Lesson_ID");
            CreateIndex("dbo.Rates", "Lesson_ID");
            AddForeignKey("dbo.Rates", "Lesson_ID", "dbo.Lessons", "ID");
        }
    }
}
