namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_JobCategoryModel_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobCategories", "AddedBy", c => c.String());
            AlterColumn("dbo.JobCategories", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobCategories", "ModifiedBy", c => c.String(nullable: false));
            AlterColumn("dbo.JobCategories", "AddedBy", c => c.String(nullable: false));
        }
    }
}
