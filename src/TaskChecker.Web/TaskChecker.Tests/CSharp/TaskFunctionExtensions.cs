using FluentAssertions;
using TaskChecker.Core;

namespace TaskChecker.Tests.CSharp
{
    public static class TaskFunctionExtensions
    {
        public static T GetSubject<T>(this TaskFunction taskFunction, params object[] parameters)
        {
            var functionReturn = taskFunction(parameters);
            functionReturn.Should().NotBeNull();
            functionReturn.Should().BeAssignableTo<T>();

            return (T)functionReturn;
        }
    }
}