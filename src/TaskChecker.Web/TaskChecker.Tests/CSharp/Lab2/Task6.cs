using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab2
{
    public class Task6
    {
        public void Test1_Unique(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { new[] { 1, 2, 3, 4} });
            functionReturn.Should().BeOfType<int[]>();

            var result = (int[])functionReturn;
            result.Should().HaveCount(4);
            result.Should().Contain(1);
            result.Should().Contain(2);
            result.Should().Contain(3);
            result.Should().Contain(4);
        }

        public void Test2_AllTheSame(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { new[] { 1, 1, 1, 1 } });
            functionReturn.Should().BeOfType<int[]>();

            var result = (int[])functionReturn;
            result.Should().HaveCount(1);
            result.Should().Contain(1);
        }

        public void Test3_Sequence(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { new[] { 1, 1, 2, 3, 4, 1, 2, 4 } });
            functionReturn.Should().BeOfType<int[]>();

            var result = (int[])functionReturn;
            result.Should().HaveCount(1);
            result.Should().Contain(3);
        }
    }
}
