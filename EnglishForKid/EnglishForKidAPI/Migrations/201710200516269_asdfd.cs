namespace EnglishForKidAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfd : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FeedbackReplyHistory", "FeedbackID");
            AddForeignKey("dbo.FeedbackReplyHistory", "FeedbackID", "dbo.Feedback", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedbackReplyHistory", "FeedbackID", "dbo.Feedback");
            DropIndex("dbo.FeedbackReplyHistory", new[] { "FeedbackID" });
        }
    }
}
