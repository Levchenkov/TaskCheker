using FluentAssertions;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab7
{
    public class Task5
    {
        public void Test1(TaskFunction taskFunction)
        {
            var subject = taskFunction.GetSubject<int[][]>(2);

            subject.Should().NotBeNull();

            var line = subject[0];
            line.Should().BeEquivalentTo(new[] { 1, 0 });

            line = subject[1];
            line.Should().BeEquivalentTo(new[] { 1, 2 });
        }

        public void Test2(TaskFunction taskFunction)
        {
            var subject = taskFunction.GetSubject<int[][]>(5);

            subject.Should().NotBeNull();

            var line = subject[0];
            line.Should().BeEquivalentTo(new[] { 1, 0, 0, 0, 0 });

            line = subject[1];
            line.Should().BeEquivalentTo(new[] { 1, 2, 0, 0, 0 });

            line = subject[2];
            line.Should().BeEquivalentTo(new[] { 1, 2, 3, 0, 0 });

            line = subject[3];
            line.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 0 });

            line = subject[4];
            line.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
        }
    }
}