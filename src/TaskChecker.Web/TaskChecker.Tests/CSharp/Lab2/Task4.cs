using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab2
{
    public class Task4
    {
        public void Test1_EmailProvided(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "eugene@yandex.by" });
            functionReturn.Should().BeOfType<string>();

            var result = (string)functionReturn;
            result.Should().Be("e*****@yandex.by");
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

            functionReturn.Should().BeNull();
        }
    }
}
