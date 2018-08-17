namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsOpened = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                        ExerciseTestSet_Id = c.Int(),
                        LabWork_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExerciseTestSets", t => t.ExerciseTestSet_Id)
                .ForeignKey("dbo.LabWorks", t => t.LabWork_Id)
                .Index(t => t.ExerciseTestSet_Id)
                .Index(t => t.LabWork_Id);
            
            CreateTable(
                "dbo.ExerciseTestSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExerciseTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        ExerciseTestSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExerciseTestSets", t => t.ExerciseTestSet_Id)
                .Index(t => t.ExerciseTestSet_Id);
            
            CreateTable(
                "dbo.LabWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsOpened = c.Boolean(nullable: false),
                        DueDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExerciseTestResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Information = c.String(),
                        IsPassed = c.Boolean(nullable: false),
                        ExerciseTest_Id = c.Int(),
                        SubmissionResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExerciseTests", t => t.ExerciseTest_Id)
                .ForeignKey("dbo.SubmissionResults", t => t.SubmissionResult_Id)
                .Index(t => t.ExerciseTest_Id)
                .Index(t => t.SubmissionResult_Id);
            
           CreateTable(
                "dbo.SubmissionResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsFinal = c.Boolean(nullable: false),
                        IsTested = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Student_Id = c.Int(),
                        SubmissionResult_Id = c.Int(),
                        SubmittedContent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.SubmissionResults", t => t.SubmissionResult_Id)
                .ForeignKey("dbo.SubmittedContents", t => t.SubmittedContent_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.SubmissionResult_Id)
                .Index(t => t.SubmittedContent_Id);
            
            CreateTable(
                "dbo.SubmittedContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        TypeName = c.String(),
                        MethodName = c.String(),
                        IsStatic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCourseClasses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        CourseClass_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.CourseClass_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseClasses", t => t.CourseClass_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.CourseClass_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "SubmittedContent_Id", "dbo.SubmittedContents");
            DropForeignKey("dbo.Submissions", "SubmissionResult_Id", "dbo.SubmissionResults");
            DropForeignKey("dbo.Submissions", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.ExerciseTestResults", "SubmissionResult_Id", "dbo.SubmissionResults");
            DropForeignKey("dbo.ExerciseTestResults", "ExerciseTest_Id", "dbo.ExerciseTests");
            DropForeignKey("dbo.Exercises", "LabWork_Id", "dbo.LabWorks");
            DropForeignKey("dbo.Exercises", "ExerciseTestSet_Id", "dbo.ExerciseTestSets");
            DropForeignKey("dbo.ExerciseTests", "ExerciseTestSet_Id", "dbo.ExerciseTestSets");
            DropForeignKey("dbo.Students", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentCourseClasses", "CourseClass_Id", "dbo.CourseClasses");
            DropForeignKey("dbo.StudentCourseClasses", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentCourseClasses", new[] { "CourseClass_Id" });
            DropIndex("dbo.StudentCourseClasses", new[] { "Student_Id" });
            DropIndex("dbo.Submissions", new[] { "SubmittedContent_Id" });
            DropIndex("dbo.Submissions", new[] { "SubmissionResult_Id" });
            DropIndex("dbo.Submissions", new[] { "Student_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ExerciseTestResults", new[] { "SubmissionResult_Id" });
            DropIndex("dbo.ExerciseTestResults", new[] { "ExerciseTest_Id" });
            DropIndex("dbo.ExerciseTests", new[] { "ExerciseTestSet_Id" });
            DropIndex("dbo.Exercises", new[] { "LabWork_Id" });
            DropIndex("dbo.Exercises", new[] { "ExerciseTestSet_Id" });
            DropIndex("dbo.Students", new[] { "User_Id" });
            DropTable("dbo.StudentCourseClasses");
            DropTable("dbo.SubmittedContents");
            DropTable("dbo.Submissions");
            DropTable("dbo.SubmissionResults");
            DropTable("dbo.ExerciseTestResults");
            DropTable("dbo.LabWorks");
            DropTable("dbo.ExerciseTests");
            DropTable("dbo.ExerciseTestSets");
            DropTable("dbo.Exercises");
            DropTable("dbo.Students");
            DropTable("dbo.CourseClasses");
        }
    }
}
