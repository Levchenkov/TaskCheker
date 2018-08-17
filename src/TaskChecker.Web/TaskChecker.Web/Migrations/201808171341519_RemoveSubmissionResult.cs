namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSubmissionResult : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExerciseTestResults", "SubmissionResult_Id", "dbo.SubmissionResults");
            DropForeignKey("dbo.Submissions", "SubmissionResult_Id", "dbo.SubmissionResults");
            DropIndex("dbo.ExerciseTestResults", new[] { "SubmissionResult_Id" });
            DropIndex("dbo.Submissions", new[] { "SubmissionResult_Id" });
            AddColumn("dbo.ExerciseTestResults", "Submission_Id", c => c.Int());
            CreateIndex("dbo.ExerciseTestResults", "Submission_Id");
            AddForeignKey("dbo.ExerciseTestResults", "Submission_Id", "dbo.Submissions", "Id");
            DropColumn("dbo.ExerciseTestResults", "SubmissionResult_Id");
            DropColumn("dbo.Submissions", "SubmissionResult_Id");
            DropTable("dbo.SubmissionResults");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubmissionResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Submissions", "SubmissionResult_Id", c => c.Int());
            AddColumn("dbo.ExerciseTestResults", "SubmissionResult_Id", c => c.Int());
            DropForeignKey("dbo.ExerciseTestResults", "Submission_Id", "dbo.Submissions");
            DropIndex("dbo.ExerciseTestResults", new[] { "Submission_Id" });
            DropColumn("dbo.ExerciseTestResults", "Submission_Id");
            CreateIndex("dbo.Submissions", "SubmissionResult_Id");
            CreateIndex("dbo.ExerciseTestResults", "SubmissionResult_Id");
            AddForeignKey("dbo.Submissions", "SubmissionResult_Id", "dbo.SubmissionResults", "Id");
            AddForeignKey("dbo.ExerciseTestResults", "SubmissionResult_Id", "dbo.SubmissionResults", "Id");
        }
    }
}
