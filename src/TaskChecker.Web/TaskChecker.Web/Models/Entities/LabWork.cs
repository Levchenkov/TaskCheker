using System;
using System.Collections.Generic;

namespace TaskChecker.Web.Models.Entities
{
    public class LabWork
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public bool IsOpened
        {
            get;
            set;
        }

        public DateTime? DueDate
        {
            get;
            set;
        }

        public virtual IList<Exercise> Exercises
        {
            get;
            set;
        }

        public virtual IList<CourseClass> CourseClasses
        {
            get;
            set;
        }
    }
}