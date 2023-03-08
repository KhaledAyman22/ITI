namespace Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Gender", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Salary", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Gender");
        }
    }
}
