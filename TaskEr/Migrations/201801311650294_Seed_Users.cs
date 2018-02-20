namespace TaskEr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed_Users : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3746aa62-05dd-4f7b-bb73-61130454b289', N'admin@app.com', 0, N'AF6oHEIfFYy+ocMXZg8u+y+0ESeVfHOEOzk4yNL15fOZbjpiQbe0hSmLDb0sy0AXyA==', N'cac84705-b6b5-4ff9-b95d-6cb099b030f2', NULL, 0, 0, NULL, 1, 0, N'admin@app.com')");
        }
        
        public override void Down()
        {
        }
    }
}
