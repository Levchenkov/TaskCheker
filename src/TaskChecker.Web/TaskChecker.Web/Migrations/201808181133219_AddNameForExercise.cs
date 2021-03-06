namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameForExercise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "Name");
        }
    }
}
