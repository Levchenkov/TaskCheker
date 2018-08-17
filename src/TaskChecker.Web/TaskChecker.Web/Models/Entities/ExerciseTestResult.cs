namespace TaskChecker.Web.Models.Entities
{
    public class ExerciseTestResult
    {
        public int Id
        {
            get;
            set;
        }

        public string Information
        {
            get;
            set;
        }

        public bool IsPassed
        {
            get;
            set;
        }
    }
}