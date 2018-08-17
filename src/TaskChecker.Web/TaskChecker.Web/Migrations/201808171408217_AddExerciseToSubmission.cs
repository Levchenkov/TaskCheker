namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExerciseToSubmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "Exercise_Id", c => c.Int());
            CreateIndex("dbo.Submissions", "Exercise_Id");
            AddForeignKey("dbo.Submissions", "Exercise_Id", "dbo.Exercises", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "Exercise_Id", "dbo.Exercises");
            DropIndex("dbo.Submissions", new[] { "Exercise_Id" });
            DropColumn("dbo.Submissions", "Exercise_Id");
        }
    }
}
