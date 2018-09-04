using FluentAssertions;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab7
{
    public class Task1
    {
        public void Test1_Numbers(TaskFunction taskFunction)
        {
            var subject = taskFunction.GetSubject<string>("0123 0456 078910");

            subject.Should().Be("123 456 78910");
        }

        public void Test2_Hamlet(TaskFunction taskFunction)
        {
            var subject = taskFunction.GetSubject<string>("To be, or not to be, that is the question.");

            subject.Should().Be("o e, r ot o e, hat s he uestion.");
        }
    }
}
