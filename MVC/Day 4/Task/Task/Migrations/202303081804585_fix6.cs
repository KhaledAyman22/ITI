namespace Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "EmailConfirmation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmailConfirmation", c => c.String(nullable: false));
        }
    }
}
