using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskChecker.Web.Models.Entities
{
    public class Student
    {
        public int Id
        {
            get;
            set;
        }

        public ApplicationUser User
        {
            get;
            set;
        }

        public IList<CourseClass> Courses
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }
    }
}