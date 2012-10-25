using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Core
{
    public static class AssemblyScanner
    {
        static AssemblyScanner() {
            var assemblyResolver = new DefaultAssemblyResolver();
            var readerParams = new ReaderParameters { AssemblyResolver = assemblyResolver };
            var assemblies = AppDomain.CurrentDomain
                                      .GetAssemblies()
                                      .Select(a => {
                                          string name = a.ManifestModule.FullyQualifiedName;
                                          return AssemblyDefinition.ReadAssembly(name);
                                      });
        }
    }
}
