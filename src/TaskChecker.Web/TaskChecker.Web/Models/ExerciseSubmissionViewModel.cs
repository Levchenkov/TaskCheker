using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskChecker.Web.Models
{
    public class ExerciseSubmissionViewModel
    {
        public int ExerciseId
        {
            get;
            set;
        }

        public string TypeName
        {
            get;
            set;
        }

        public string MethodName
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }
    }
}