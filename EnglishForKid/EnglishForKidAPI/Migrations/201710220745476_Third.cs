namespace EnglishForKidAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Result", "ApplicationUserID", "dbo.User");
            DropIndex("dbo.Result", new[] { "ApplicationUserID" });
            DropColumn("dbo.Result", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Result", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Result", "ApplicationUserID");
            AddForeignKey("dbo.Result", "ApplicationUserID", "dbo.User", "Id");
        }
    }
}
