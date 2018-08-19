using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab2
{
    public class Task5
    {
        public void Test1_Simple(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "12333456" });
            functionReturn.Should().BeOfType<int>();

            var result = (int)functionReturn;
            result.Should().Be(3);
        }

        public void Test2_TwoSequences(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "12333444456" });
            functionReturn.Should().BeOfType<int>();

            var result = (int)functionReturn;
            result.Should().Be(4);
        }

        public void Test3_Unique(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "123456789" });
            functionReturn.Should().BeOfType<int>();

            var result = (int)functionReturn;
            result.Should().Be(1);
        }
    }
}
