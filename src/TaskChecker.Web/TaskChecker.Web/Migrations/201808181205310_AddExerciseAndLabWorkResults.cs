namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExerciseAndLabWorkResults : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.Int(nullable: false),
                        Exercise_Id = c.Int(),
                        Student_Id = c.Int(),
                        Submission_Id = c.Int(),
                        LabWorkResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercises", t => t.Exercise_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Submissions", t => t.Submission_Id)
                .ForeignKey("dbo.LabWorkResults", t => t.LabWorkResult_Id)
                .Index(t => t.Exercise_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Submission_Id)
                .Index(t => t.LabWorkResult_Id);
            
            CreateTable(
                "dbo.LabWorkResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.Int(nullable: false),
                        LabWork_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LabWorks", t => t.LabWork_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.LabWork_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LabWorkResults", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.LabWorkResults", "LabWork_Id", "dbo.LabWorks");
            DropForeignKey("dbo.ExerciseResults", "LabWorkResult_Id", "dbo.LabWorkResults");
            DropForeignKey("dbo.ExerciseResults", "Submission_Id", "dbo.Submissions");
            DropForeignKey("dbo.ExerciseResults", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.ExerciseResults", "Exercise_Id", "dbo.Exercises");
            DropIndex("dbo.LabWorkResults", new[] { "Student_Id" });
            DropIndex("dbo.LabWorkResults", new[] { "LabWork_Id" });
            DropIndex("dbo.ExerciseResults", new[] { "LabWorkResult_Id" });
            DropIndex("dbo.ExerciseResults", new[] { "Submission_Id" });
            DropIndex("dbo.ExerciseResults", new[] { "Student_Id" });
            DropIndex("dbo.ExerciseResults", new[] { "Exercise_Id" });
            DropTable("dbo.LabWorkResults");
            DropTable("dbo.ExerciseResults");
        }
    }
}
