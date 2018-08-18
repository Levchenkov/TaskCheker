using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskChecker.Web.Models.Entities
{
    public class LabWorkResult
    {
        public int Id
        {
            get;
            set;
        }

        public LabWork LabWork
        {
            get;
            set;
        }

        public Student Student
        {
            get;
            set;
        }

        public int Mark
        {
            get;
            set;
        }

        public virtual IList<ExerciseResult> ExerciseResults
        {
            get;
            set;
        }
    }
}