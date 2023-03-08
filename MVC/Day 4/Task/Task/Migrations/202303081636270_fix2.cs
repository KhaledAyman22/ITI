namespace Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "JoinDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "JoinDate", c => c.String(nullable: false));
        }
    }
}
