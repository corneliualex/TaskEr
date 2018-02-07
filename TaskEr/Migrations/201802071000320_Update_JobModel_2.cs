namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_JobModel_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "TimeStarted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "TimeEnded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "TimeEnded");
            DropColumn("dbo.Jobs", "TimeStarted");
        }
    }
}
