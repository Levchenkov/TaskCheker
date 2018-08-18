namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameIsRequiredInLabWork : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LabWorks", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LabWorks", "Name", c => c.String());
        }
    }
}
