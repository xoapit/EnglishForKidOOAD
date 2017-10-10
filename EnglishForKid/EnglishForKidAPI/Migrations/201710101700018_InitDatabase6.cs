namespace EnglishForKidAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rates", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "Levels_ID", "dbo.Levels");
            DropIndex("dbo.Lessons", new[] { "Levels_ID" });
            DropIndex("dbo.Rates", new[] { "LessonID" });
            RenameColumn(table: "dbo.Lessons", name: "Levels_ID", newName: "LevelID");
            AlterColumn("dbo.Lessons", "LevelID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Lessons", "LevelID");
            AddForeignKey("dbo.Lessons", "LevelID", "dbo.Levels", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "LevelID", "dbo.Levels");
            DropIndex("dbo.Lessons", new[] { "LevelID" });
            AlterColumn("dbo.Lessons", "LevelID", c => c.Guid());
            RenameColumn(table: "dbo.Lessons", name: "LevelID", newName: "Levels_ID");
            CreateIndex("dbo.Rates", "LessonID");
            CreateIndex("dbo.Lessons", "Levels_ID");
            AddForeignKey("dbo.Lessons", "Levels_ID", "dbo.Levels", "ID");
            AddForeignKey("dbo.Rates", "LessonID", "dbo.Lessons", "ID", cascadeDelete: true);
        }
    }
}
