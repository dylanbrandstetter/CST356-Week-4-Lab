namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratoion7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Occupation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Occupation");
        }
    }
}
