using FluentAssertions;
using Lab5;
using Moq;
using System;
using System.Collections.Generic;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp.Lab5
{
    public class Task1
    {
        private readonly Mock<ILogger> loggerMock;
        private readonly Mock<IUserRepository> userRepositoryMock;

        public Task1()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            loggerMock = new Mock<ILogger>();
        }

        public void Test1_LoginWithTruePassword_ShouldLogin(TaskFunction taskFunction)
        {
            userRepositoryMock
                .Setup(x => x.CheckPassword(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var functionReturn = taskFunction(new object[] { loggerMock.Object, userRepositoryMock.Object });
            functionReturn.Should().NotBeNull();
            functionReturn.Should().BeAssignableTo<IUserManager>();
            var manager = (IUserManager)functionReturn;

            manager.Login("First", "qwaszx@1");

            loggerMock.Verify(x => x.LogInfo(It.IsAny<string>()));
            
        }

        public void Test2_LoginWithFalsePassword_ShouldNotLogin(TaskFunction taskFunction)
        {
            userRepositoryMock
                .Setup(x => x.CheckPassword(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);

            var functionReturn = taskFunction(new object[] { loggerMock.Object, userRepositoryMock.Object });
            functionReturn.Should().NotBeNull();
            functionReturn.Should().BeAssignableTo<IUserManager>();
            var manager = (IUserManager)functionReturn;

            manager.Login("First", "qwaszx@1");

            loggerMock.Verify(x => x.LogError(It.IsAny<string>()));
        }

        public void Test3_Logout_UserNameProvided(TaskFunction taskFunction)
        {
            var functionReturn = taskFunction(new object[] { loggerMock.Object, userRepositoryMock.Object });
            functionReturn.Should().NotBeNull();
            functionReturn.Should().BeAssignableTo<IUserManager>();
            var manager = (IUserManager)functionReturn;

            manager.Logout("First");

            loggerMock.Verify(x => x.LogInfo(It.IsAny<string>()));
        }
    }
}
