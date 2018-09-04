using FluentAssertions;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab7
{
    public class Task3
    {
        public void Test1(TaskFunction taskFunction)
        {
            var subject = taskFunction.GetSubject<int[][]>(2);

            subject.Should().NotBeNull();

            var line = subject[0];
            line.Should().BeEquivalentTo(new[] { 1, 2 });

            line = subject[1];
            line.Should().BeEquivalentTo(new[] { 2, 3 });
        }

        public void Test2(TaskFunction taskFunction)
        {
            var subject = taskFunction.GetSubject<int[][]>(5);

            subject.Should().NotBeNull();

            var line = subject[0];
            line.Should().BeEquivalentTo(new []{ 1, 2, 3, 4, 5 });

            line = subject[1];
            line.Should().BeEquivalentTo(new[] { 2, 3, 4, 5, 6 });

            line = subject[2];
            line.Should().BeEquivalentTo(new[] { 3, 4, 5, 6, 7 });

            line = subject[3];
            line.Should().BeEquivalentTo(new[] { 4, 5, 6, 7, 8 });

            line = subject[4];
            line.Should().BeEquivalentTo(new[] { 5, 6, 7, 8, 9 });
        }
    }
}