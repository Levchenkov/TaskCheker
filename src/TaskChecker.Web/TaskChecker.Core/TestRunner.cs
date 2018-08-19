using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskChecker.Core
{
    public class TestRunner
    {
        private readonly Assembly assembly;

        public TestRunner(string assemblyName)
        {
            assembly = Assembly.Load(assemblyName);
        }

        public IList<TestResult> Run(string typeName, TaskFunction taskFunction)
        {
            var type = assembly.GetType(typeName);

            var results = new List<TestResult>();
            if (type == null)
            {
                results.Add(new TestResult
                {
                    IsPassed = false,
                    Exception = new NotSupportedException($"Test {typeName} not found.")
                });
                return results;
            }

            var tests = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var test in tests)
            {
                var testResult = new TestResult
                {
                    TestName = $"{type.FullName}.{test.Name}"
                };

                try
                {
                    var testClassInstance = Activator.CreateInstance(type);
                    test.Invoke(testClassInstance, new object[] {taskFunction});

                    testResult.IsPassed = true;
                }
                catch (Exception exception)
                {
                    testResult.IsPassed = false;
                    testResult.Exception = exception;
                }

                results.Add(testResult);
            }

            return results;
        }
    }
}
