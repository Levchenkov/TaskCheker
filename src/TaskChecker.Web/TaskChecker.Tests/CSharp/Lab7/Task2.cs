using FluentAssertions;
using Lab7;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab7
{
    public class Task2
    {
        public void Test1(TaskFunction taskFunction)
        {
            var matrix = new [,]
            {
                { 1, 2, 3, 4},
                { 1, 2, 3, 4},
                { 1, 2, 3, 4},
                { 1, 2, 3, 4},
            };

            var subject = taskFunction.GetSubject<IMatrix>(matrix);

            subject.MainDiagonal.Should().BeEquivalentTo(new[] { 1, 2, 3, 4 });
            subject.SideDiagonal.Should().BeEquivalentTo(new [] { 1, 2, 3, 4 });
        }

        public void Test2(TaskFunction taskFunction)
        {
            var matrix = new[,]
            {
                { 1, 2, 3, 9},
                { 1, 4, 8, 10},
                { 5, 7, 11, 14},
                { 6, 12, 13, 15},
            };

            var subject = taskFunction.GetSubject<IMatrix>(matrix);

            subject.MainDiagonal.Should().BeEquivalentTo(new[] { 1, 4, 11, 15 });
            subject.SideDiagonal.Should().BeEquivalentTo(new[] { 6, 7, 8, 9 });
        }
    }
}