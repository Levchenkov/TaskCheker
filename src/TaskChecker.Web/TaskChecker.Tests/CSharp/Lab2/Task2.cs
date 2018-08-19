using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab2
{
    public class Task2
    {
        public void Test1_FirstNameLastNameProvided(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "eugene levchenkov" });
            functionReturn.Should().BeOfType<string>();

            var result = (string)functionReturn;
            result.Should().Be("Eugene L.");
        }

        public void Test2_EmptyString(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { string.Empty });
            functionReturn.Should().BeOfType<string>();

            var result = (string)functionReturn;
            result.Should().Be("");
        }

        public void Test3_NullString(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { (string)null });

            functionReturn.Should().BeOfType<string>();

            var result = (string)functionReturn;
            result.Should().Be("");
        }
    }
}
