namespace Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmailConfirmation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmailConfirmation");
        }
    }
}
