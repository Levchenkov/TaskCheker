namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLabWorksToCourseClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LabWorks", "CourseClass_Id", c => c.Int());
            CreateIndex("dbo.LabWorks", "CourseClass_Id");
            AddForeignKey("dbo.LabWorks", "CourseClass_Id", "dbo.CourseClasses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LabWorks", "CourseClass_Id", "dbo.CourseClasses");
            DropIndex("dbo.LabWorks", new[] { "CourseClass_Id" });
            DropColumn("dbo.LabWorks", "CourseClass_Id");
        }
    }
}
