using FluentAssertions;
using System.Collections.Generic;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab1
{
    public class Task2
    {
        public void Test1(TaskFunction taskFunction)
        {
            var rawResult = taskFunction(new object[] {new List<int> {1, 2, 3}});
            rawResult.Should().BeOfType<List<int>>();

            var result = (List<int>) rawResult;
            result.Should().ContainInOrder(3, 2, 1);
        }

        public void Test2(TaskFunction taskFunction)
        {
            var rawResult = taskFunction(new object[] { new List<int> { 1, 2, 3 } });
            rawResult.Should().BeOfType<List<int>>();

            var result = (List<int>)rawResult;
            result.Should().ContainInOrder(1, 2, 3);
        }
    }
}
