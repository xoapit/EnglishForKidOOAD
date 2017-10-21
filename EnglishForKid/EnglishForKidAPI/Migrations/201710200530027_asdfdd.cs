namespace EnglishForKidAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeedbackReplyHistory", "FeedbackID", "dbo.Feedback");
            DropIndex("dbo.FeedbackReplyHistory", new[] { "FeedbackID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.FeedbackReplyHistory", "FeedbackID");
            AddForeignKey("dbo.FeedbackReplyHistory", "FeedbackID", "dbo.Feedback", "ID", cascadeDelete: true);
        }
    }
}
