using System.Collections.Generic;
using TaskChecker.Web.Models.Entities;

namespace TaskChecker.Web.Models
{
    public class ExerciseViewModel
    {
        public Exercise Exercise
        {
            get;
            set;
        }

        public ExerciseResult ExerciseResult
        {
            get;
            set;
        }

        public IEnumerable<Submission> Submissions
        {
            get;
            set;
        }
    }
}