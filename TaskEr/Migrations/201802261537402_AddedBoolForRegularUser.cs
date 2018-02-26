namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoolForRegularUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "isRegularUser", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "isRegularUser");
        }
    }
}
