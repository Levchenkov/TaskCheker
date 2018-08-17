namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyLabWorksAndCourseClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LabWorks", "CourseClass_Id", "dbo.CourseClasses");
            DropIndex("dbo.LabWorks", new[] { "CourseClass_Id" });
            CreateTable(
                "dbo.LabWorkCourseClasses",
                c => new
                    {
                        LabWork_Id = c.Int(nullable: false),
                        CourseClass_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LabWork_Id, t.CourseClass_Id })
                .ForeignKey("dbo.LabWorks", t => t.LabWork_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseClasses", t => t.CourseClass_Id, cascadeDelete: true)
                .Index(t => t.LabWork_Id)
                .Index(t => t.CourseClass_Id);
            
            DropColumn("dbo.LabWorks", "CourseClass_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LabWorks", "CourseClass_Id", c => c.Int());
            DropForeignKey("dbo.LabWorkCourseClasses", "CourseClass_Id", "dbo.CourseClasses");
            DropForeignKey("dbo.LabWorkCourseClasses", "LabWork_Id", "dbo.LabWorks");
            DropIndex("dbo.LabWorkCourseClasses", new[] { "CourseClass_Id" });
            DropIndex("dbo.LabWorkCourseClasses", new[] { "LabWork_Id" });
            DropTable("dbo.LabWorkCourseClasses");
            CreateIndex("dbo.LabWorks", "CourseClass_Id");
            AddForeignKey("dbo.LabWorks", "CourseClass_Id", "dbo.CourseClasses", "Id");
        }
    }
}
