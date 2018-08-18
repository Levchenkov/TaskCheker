using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskChecker.Web.Models.Entities
{
    public class ExerciseResult
    {
        public int Id
        {
            get;
            set;
        }

        public Exercise Exercise
        {
            get;
            set;
        }

        public Student Student
        {
            get;
            set;
        }

        public Submission Submission
        {
            get;
            set;
        }

        public int Mark
        {
            get;
            set;
        }
    }
}