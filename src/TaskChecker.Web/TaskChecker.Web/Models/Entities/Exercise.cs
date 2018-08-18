using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskChecker.Web.Models.Entities
{
    public class Exercise
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

        [DataType(DataType.MultilineText)]
        public string Description
        {
            get;
            set;
        }

        public int Value
        {
            get;
            set;
        }

        public LabWork LabWork
        {
            get;
            set;
        }

        public bool IsStatic
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

        public virtual IList<ExerciseTest> ExerciseTests
        {
            get;
            set;
        }
    }
}