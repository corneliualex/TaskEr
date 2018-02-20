namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_JobCategoryModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobCategories", "Description", c => c.String());
            AddColumn("dbo.JobCategories", "DateAdded", c => c.DateTime());
            AddColumn("dbo.JobCategories", "DateModified", c => c.DateTime());
            AddColumn("dbo.JobCategories", "AddedBy", c => c.String());
            AddColumn("dbo.JobCategories", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobCategories", "ModifiedBy");
            DropColumn("dbo.JobCategories", "AddedBy");
            DropColumn("dbo.JobCategories", "DateModified");
            DropColumn("dbo.JobCategories", "DateAdded");
            DropColumn("dbo.JobCategories", "Description");
        }
    }
}
