namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_JobModel_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "AddedDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "TimeStarted", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Jobs", "TimeEnded", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "TimeEnded", c => c.DateTime());
            AlterColumn("dbo.Jobs", "TimeStarted", c => c.DateTime(nullable: false));
            DropColumn("dbo.Jobs", "AddedDateTime");
        }
    }
}
