using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskChecker.Web.Models;
using TaskChecker.Web.Models.Entities;

namespace TaskChecker.Web.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<CourseClass> CourseClasses
        {
            get;
            set;
        }

        public DbSet<Exercise> Exercises
        {
            get;
            set;
        }

        public DbSet<ExerciseTest> ExerciseTests
        {
            get;
            set;
        }

        public DbSet<ExerciseTestResult> ExerciseTestResults
        {
            get;
            set;
        }

        public DbSet<LabWork> LabWorks
        {
            get;
            set;
        }

        public DbSet<Student> Students
        {
            get;
            set;
        }

        public DbSet<Submission> Submissions
        {
            get;
            set;
        }

        public DbSet<SubmittedContent> SubmittedContents
        {
            get;
            set;
        }

        public DbSet<ExerciseResult> ExerciseResults
        {
            get;
            set;
        }

        public DbSet<LabWorkResult> LabWorkResults
        {
            get;
            set;
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}