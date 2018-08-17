using System;

namespace TaskChecker.Core
{
    public class TestResult
    {
        public bool IsPassed
        {
            get;
            set;
        }

        public string TestName
        {
            get;
            set;
        }

        public Exception Exception
        {
            get;
            set;
        }
    }
}