namespace TaskChecker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveExerciseTestSet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExerciseTests", "ExerciseTestSet_Id", "dbo.ExerciseTestSets");
            DropForeignKey("dbo.Exercises", "ExerciseTestSet_Id", "dbo.ExerciseTestSets");
            DropIndex("dbo.Exercises", new[] { "ExerciseTestSet_Id" });
            DropIndex("dbo.ExerciseTests", new[] { "ExerciseTestSet_Id" });
            AddColumn("dbo.ExerciseTests", "Exercise_Id", c => c.Int());
            CreateIndex("dbo.ExerciseTests", "Exercise_Id");
            AddForeignKey("dbo.ExerciseTests", "Exercise_Id", "dbo.Exercises", "Id");
            DropColumn("dbo.Exercises", "ExerciseTestSet_Id");
            DropColumn("dbo.ExerciseTests", "ExerciseTestSet_Id");
            DropTable("dbo.ExerciseTestSets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExerciseTestSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ExerciseTests", "ExerciseTestSet_Id", c => c.Int());
            AddColumn("dbo.Exercises", "ExerciseTestSet_Id", c => c.Int());
            DropForeignKey("dbo.ExerciseTests", "Exercise_Id", "dbo.Exercises");
            DropIndex("dbo.ExerciseTests", new[] { "Exercise_Id" });
            DropColumn("dbo.ExerciseTests", "Exercise_Id");
            CreateIndex("dbo.ExerciseTests", "ExerciseTestSet_Id");
            CreateIndex("dbo.Exercises", "ExerciseTestSet_Id");
            AddForeignKey("dbo.Exercises", "ExerciseTestSet_Id", "dbo.ExerciseTestSets", "Id");
            AddForeignKey("dbo.ExerciseTests", "ExerciseTestSet_Id", "dbo.ExerciseTestSets", "Id");
        }
    }
}
