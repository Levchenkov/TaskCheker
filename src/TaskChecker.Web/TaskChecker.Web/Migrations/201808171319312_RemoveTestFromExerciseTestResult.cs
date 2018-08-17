namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTestFromExerciseTestResult : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExerciseTestResults", "ExerciseTest_Id", "dbo.ExerciseTests");
            DropIndex("dbo.ExerciseTestResults", new[] { "ExerciseTest_Id" });
            DropColumn("dbo.ExerciseTestResults", "ExerciseTest_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExerciseTestResults", "ExerciseTest_Id", c => c.Int());
            CreateIndex("dbo.ExerciseTestResults", "ExerciseTest_Id");
            AddForeignKey("dbo.ExerciseTestResults", "ExerciseTest_Id", "dbo.ExerciseTests", "Id");
        }
    }
}
