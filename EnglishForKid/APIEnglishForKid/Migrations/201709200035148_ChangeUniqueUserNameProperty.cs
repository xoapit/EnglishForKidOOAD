namespace APIEnglishForKid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUniqueUserNameProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "UserName", c => c.String(maxLength: 50));
            CreateIndex("dbo.Accounts", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "UserName" });
            AlterColumn("dbo.Accounts", "UserName", c => c.String());
        }
    }
}
