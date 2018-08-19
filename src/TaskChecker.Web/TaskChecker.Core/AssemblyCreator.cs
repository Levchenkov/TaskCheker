using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using con = System.Console;

namespace TaskChecker
{
    public class AssemblyCreator
    {
        public AssemblyCreator(string content)
        {
            Content = content;
        }

        public string Content
        {
            get;
        }

        public Assembly CreateAssembly()
        {
            var tree = CSharpSyntaxTree.ParseText(Content);

            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(Object).Assembly.Location), // System
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location), // System.Linq
                MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location) // System.Collections.Generic, mscorlib
            };

            var assemblyName = $"GeneratedAssembly-{Guid.NewGuid():N}";
            var compilation = CSharpCompilation.Create(
                assemblyName,
                new[] { tree },
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            ThrowIfContainsConsoleReadLine(tree, compilation);

            using (var stream = new MemoryStream())
            {
                var emitResult = compilation.Emit(stream);

                if (!emitResult.Success)
                {
                    var errors = emitResult.Diagnostics.Where(x => x.IsWarningAsError || x.Severity == DiagnosticSeverity.Error);

                    var message = string.Join("\n", errors.Select(x => $"{x.Id}: {x.GetMessage()}"));
                    
                    throw new NotSupportedException(message);
                }
                else
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    return Assembly.Load(stream.ToArray());
                }
            }
        }

        private void ThrowIfContainsConsoleReadLine(SyntaxTree syntaxTree, CSharpCompilation compilation)
        {
            var model = compilation.GetSemanticModel(syntaxTree);
            var invocationSyntaxes = syntaxTree.GetRoot().DescendantNodes().OfType<InvocationExpressionSyntax>();

            foreach (var invocationSyntax in invocationSyntaxes)
            {
                var symbolInfo = model.GetSymbolInfo(invocationSyntax);
                var methodName = $"{symbolInfo.Symbol.ContainingType.ToString()}.{symbolInfo.Symbol.Name}";
                if (GetDeprecatedMethods().Contains(methodName))
                {
                    throw new NotSupportedException($"Method {methodName} is not allowed.");
                }
            }
        }

        private IEnumerable<string> GetDeprecatedMethods()
        {
            yield return "System.Console.Read";
            yield return "System.Console.ReadKey";
            yield return "System.Console.ReadLine";
        }
    }
}