namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed_JobCategories : DbMigration
    {
        public override void Up()
        {
            Sql("insert into JobCategories(Name) values ('JobCategory1'),('JobCategory2'),('JobCategory3')");
        }
        
        public override void Down()
        {
        }
    }
}
