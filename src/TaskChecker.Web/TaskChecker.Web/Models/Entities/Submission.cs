using System;
using System.Collections.Generic;

namespace TaskChecker.Web.Models.Entities
{
    public class Submission
    {
        public int Id
        {
            get;
            set;
        }

        public Student Student
        {
            get;
            set;
        }

        public bool IsFinal
        {
            get;
            set;
        }

        public bool IsTested
        {
            get;
            set;
        }

        public DateTime Created
        {
            get;
            set;
        }

        public Exercise Exercise
        {
            get;
            set;
        }

        public SubmittedContent SubmittedContent
        {
            get;
            set;
        }

        public virtual IList<ExerciseTestResult> TestResults
        {
            get;
            set;
        }
    }
}