namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated_JobModel_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jobs", "ApplicationUserId");
            AddForeignKey("dbo.Jobs", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Jobs", new[] { "ApplicationUserId" });
            DropColumn("dbo.Jobs", "ApplicationUserId");
        }
    }
}
