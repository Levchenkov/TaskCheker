using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab2
{
    public class Task3
    {
        public void Test1_SsnProvided(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { "123456789" });
            functionReturn.Should().BeOfType<string>();

            var result = (string)functionReturn;
            result.Should().Be("*****6789");
        }
    }
}
