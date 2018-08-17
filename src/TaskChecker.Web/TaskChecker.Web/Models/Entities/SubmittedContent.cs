namespace TaskChecker.Web.Models.Entities
{
    public class SubmittedContent
    {
        public int Id
        {
            get;
            set;
        }

        public string Content
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

        public bool IsStatic
        {
            get;
            set;
        }
    }
}