using FluentAssertions;
using Lab5;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab5
{
    public class Task2
    {
        public void Test1_OnePushOnePop_ShouldBeEmpty(TaskFunction taskFunction)
        {
            var queue = CheckAndGet(taskFunction);
            queue.IsEmpty.Should().BeTrue("Initialized collection should be empty.");
            queue.Count.Should().Be(0, "Initialized collection should have count 0.");

            queue.Enqueue(1);
            queue.Peek().Should().Be(1, "Enqueue element 1, Peek should return 1.");
            queue.Dequeue().Should().Be(1, "Enqueue element 1, Dequeue should return 1.");
            queue.IsEmpty.Should().BeTrue("Enqueue element 1, Denqueue element 1. Collection should be empty.");
            queue.Count.Should().Be(0, "Enqueue element 1, Denqueue element 1. Collection should have count 0.");
        }

        public void Test2_ManyPushAndPop_ShouldBeEqual(TaskFunction taskFunction)
        {
            var queue = CheckAndGet(taskFunction);
            queue.IsEmpty.Should().BeTrue();
            queue.Count.Should().Be(0);

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            queue.IsEmpty.Should().BeFalse();
            queue.Count.Should().Be(10);

            for (int i = 0; i < 10; i++)
            {
                queue.Peek().Should().Be(i);
                queue.Dequeue().Should().Be(i);
            }
        }

        public void Test3(TaskFunction taskFunction)
        {
            var queue = CheckAndGet(taskFunction);
            queue.IsEmpty.Should().BeTrue();
            queue.Count.Should().Be(0);

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            var array = queue.ToArray();
            array.Should().HaveCount(10);

            for (int i = 0; i < 10; i++)
            {
                array[i].Should().Be(i);
            }
        }

        private IQueue<int> CheckAndGet(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(null);
            functionReturn.Should().NotBeNull();
            functionReturn.Should().BeAssignableTo<IQueue<int>>();

            return (IQueue<int>)functionReturn;
        }
    }
}
