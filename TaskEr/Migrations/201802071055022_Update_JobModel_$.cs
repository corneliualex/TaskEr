namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_JobModel_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "TimeSpent", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "TimeSpent");
        }
    }
}
