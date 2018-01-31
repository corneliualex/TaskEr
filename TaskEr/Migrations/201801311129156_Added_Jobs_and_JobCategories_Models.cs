namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Jobs_and_JobCategories_Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        JobCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobCategories", t => t.JobCategoryId, cascadeDelete: true)
                .Index(t => t.JobCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "JobCategoryId", "dbo.JobCategories");
            DropIndex("dbo.Jobs", new[] { "JobCategoryId" });
            DropTable("dbo.Jobs");
            DropTable("dbo.JobCategories");
        }
    }
}
