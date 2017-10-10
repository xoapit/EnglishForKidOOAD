namespace EnglishForKidAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "Discussion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "Discussion");
        }
    }
}
