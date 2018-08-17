namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToExercise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "IsStatic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exercises", "TypeName", c => c.String());
            AddColumn("dbo.Exercises", "MethodName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "MethodName");
            DropColumn("dbo.Exercises", "TypeName");
            DropColumn("dbo.Exercises", "IsStatic");
        }
    }
}
