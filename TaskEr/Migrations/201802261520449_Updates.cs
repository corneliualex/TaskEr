namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Description", c => c.String(nullable: false));
        }
    }
}
