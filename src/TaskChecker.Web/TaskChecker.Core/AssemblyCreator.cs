using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

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
                MetadataReference.CreateFromFile(typeof(Object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(List<>).Assembly.Location)
            };

            var assemblyName = $"GeneratedAssembly-{Guid.NewGuid():N}";
            var compilation = CSharpCompilation.Create(
                assemblyName,
                new[] { tree },
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var stream = new MemoryStream())
            {
                var emitResult = compilation.Emit(stream);

                if (!emitResult.Success)
                {
                    var errors = emitResult.Diagnostics.Where(x => x.IsWarningAsError || x.Severity == DiagnosticSeverity.Error);

                    foreach (var error in errors)
                    {
                        Console.Error.WriteLine("{0}: {1}", error.Id, error.GetMessage());
                    }
                    throw new NotSupportedException();
                }
                else
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    return Assembly.Load(stream.ToArray());
                }
            }
        }
    }
}