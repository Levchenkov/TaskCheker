using FluentAssertions;
using Lab6;
using Moq;
using System;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab6
{
    public class Task1
    {
        private readonly Mock<IFile> fileMock;

        public Task1()
        {
            fileMock = new Mock<IFile>();
        }

        public void Test1_ReadSafe_ShouldReturnDefaultResult(TaskFunction taskFunction)
        {
            fileMock.Setup(x => x.Read()).Throws<Exception>();

            IFileReader subject = GetSubject(taskFunction);

            string result = "asd";
            Action action = () => result = subject.ReadSafe();

            action.Should().NotThrow("Should not throw because safe method.");

            fileMock.Verify(x => x.Open(), Times.Once);
            fileMock.Verify(x => x.Read(), Times.Once);
            fileMock.Verify(x => x.Close(), Times.Once);

            result.Should().BeNull("When you read file and catch exception in safe method, " +
                "you should return default result.");
        }

        public void Test2_Read_ShouldThrowException(TaskFunction taskFunction)
        {
            var exception = new Exception();
            fileMock.Setup(x => x.Read()).Throws(exception);

            IFileReader subject = GetSubject(taskFunction);

            Action action = () => subject.Read();

            try
            {
                action();
            }
            catch (Exception)
            {
            }

            fileMock.Verify(x => x.Open(), Times.Once);
            fileMock.Verify(x => x.Read(), Times.Once);
            fileMock.Verify(x => x.Close(), Times.Once);

            var actualException = action
                .Should()
                .Throw<Exception>("When you read file and catch exception " +
                "in non-safe method, you should throw exception.")
                .Which;

            actualException
                .GetType()
                .Name
                .Should()
                .Be(
                    "FileReaderException",
                    "Throwed exception should have name FileReaderException.");

            actualException.InnerException.Should().Be(exception, "Throwed exception should be inner.");
        }

        private IFileReader GetSubject(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new[] { fileMock.Object });
            functionReturn.Should().NotBeNull();
            functionReturn.Should().BeAssignableTo<IFileReader>();

            return (IFileReader)functionReturn;
        }
    }
}
