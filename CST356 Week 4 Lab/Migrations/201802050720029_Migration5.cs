namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
        }
    }
}
