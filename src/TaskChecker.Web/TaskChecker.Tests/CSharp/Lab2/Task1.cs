using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab2
{
    public class Task1
    {
        public void Test1_UniqueString(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "123456789", "1", "9" });
            functionReturn.Should().BeOfType<int>();

            var result = (int)functionReturn;
            result.Should().Be(8);
        }

        public void Test2_NonUniqueString(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "121459789", "1", "9" });
            functionReturn.Should().BeOfType<int>();

            var result = (int)functionReturn;
            result.Should().Be(8);
        }

        public void Test2_StringDoesNotContainSearchingChars(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "121459789", "a", "b" });
            functionReturn.Should().BeOfType<int>();

            var result = (int)functionReturn;
            result.Should().Be(0);
        }

        public void Test2_StringDoesNotContainStartChar(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "121459789", "a", "9" });
            functionReturn.Should().BeOfType<int>();

            var result = (int)functionReturn;
            result.Should().Be(0);
        }

        public void Test2_StringDoesNotContainFinishChar(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "121459789", "1", "b" });
            functionReturn.Should().BeOfType<int>();

            var result = (int)functionReturn;
            result.Should().Be(0);
        }
    }
}
