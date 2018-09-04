using Lab7;
using System;
using System.Linq.Expressions;
using System.Reflection;
using TaskChecker.Core;
using TaskChecker.Tests.CSharp.Lab7;

namespace TaskChecker.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteTest(() => Task2.Do(null), new Task1().Test1_Numbers);
        }

        static void ExecuteTest(Expression<Action> expression, Action<TaskFunction> test)
        {
            TaskFunction taskFunction = (parameters) => TaskFunction(expression, parameters);

            test(taskFunction);
        }

        static object TaskFunction(LambdaExpression expression, params object[] parameters)
        {
            var methodInfo = GetMethodInfo(expression);
            if(methodInfo!= null)
            {
                return methodInfo.Invoke(null, parameters);
            }

            throw new NotSupportedException();
        }

        public static MethodInfo GetMethodInfo(LambdaExpression expression)
        {
            MethodCallExpression outermostExpression = expression.Body as MethodCallExpression;

            if (outermostExpression == null)
            {
                throw new ArgumentException("Invalid Expression. Expression should consist of a Method call only.");
            }

            return outermostExpression.Method;
        }
    }

    public class Task2
    {
        public static string Do(string value)
        {
            return value;
        }
    }
}
