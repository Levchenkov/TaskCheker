using System.Collections.Generic;

namespace TaskChecker.Web.Models.Entities
{
    public class CourseClass
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

        public string Description
        {
            get;
            set;
        }

        public virtual IList<Student> Students
        {
            get;
            set;
        }

        public bool IsOpened
        {
            get;
            set;
        }

        public virtual IList<LabWork> LabWorks
        {
            get;
            set;
        }
    }
}