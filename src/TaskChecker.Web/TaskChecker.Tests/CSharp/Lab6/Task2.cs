using FluentAssertions;
using Lab6;
using Moq;
using System;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab6
{
    public class Task2
    {
        private readonly Mock<IRemoteService> remoteServiceMock;

        public Task2()
        {
            remoteServiceMock = new Mock<IRemoteService>();
        }

        public void Test1_EmptyData_ShouldBeSuccess(TaskFunction taskFunction)
        {
            remoteServiceMock.Setup(x => x.SendData(It.IsAny<string>())).Throws<Exception>();

            var subject = GetSubject(taskFunction);

            var result = subject.SendData(Array.Empty<string>());

            result.Should().NotBeNull("Should be an object");
            result.IsSuccess.Should().BeTrue("Should be success.");
        }

        public void Test2_ArrayData_ShouldBeFailed(TaskFunction taskFunction)
        {
            remoteServiceMock.Setup(x => x.SendData(It.IsAny<string>())).Throws<Exception>();

            var subject = GetSubject(taskFunction);

            var data = new[]
            {
                "1",
                "2",
                "3"
            };

            var result = subject.SendData(data);

            result.Should().NotBeNull("Should be an object");
            result.IsSuccess.Should().BeFalse("Should not be success.");

            result.Exceptions.Should().NotBeNull("Should be an object");
            result.Exceptions.Should().HaveCount(data.Length, "Should have the same count as data length.");
        }

        private IRemoteClient GetSubject(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new[] { remoteServiceMock.Object });
            functionReturn.Should().NotBeNull();
            functionReturn.Should().BeAssignableTo<IRemoteClient>();

            return (IRemoteClient)functionReturn;
        }
    }
}
