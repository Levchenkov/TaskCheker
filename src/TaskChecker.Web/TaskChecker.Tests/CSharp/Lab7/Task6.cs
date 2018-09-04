using FluentAssertions;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab7
{
    public class Task6
    {
        public void Test(TaskFunction taskFunction)
        {
            var subject = taskFunction.GetSubject<int[][]>(5);

            subject.Should().NotBeNull();

            var line = subject[0];
            line.Should().BeEquivalentTo(new[] { 1, 3, 4, 10, 11 });

            line = subject[1];
            line.Should().BeEquivalentTo(new[] { 2, 5, 9, 12, 19 });

            line = subject[2];
            line.Should().BeEquivalentTo(new[] { 6, 8, 13, 18, 20 });

            line = subject[3];
            line.Should().BeEquivalentTo(new[] { 15, 16, 22, 23, 25 });

            line = subject[4];
            line.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5 });
        }
    }
}
