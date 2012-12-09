using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;
using NCop.Core.Extensions;

namespace NCop.Core
{
    public class RuntimeSettings
    {
        static RuntimeSettings() {
            var objectPublicKeyToken = typeof(object).GetAssemblyPublicKeyToken();
            var binderPublicKeyToken = typeof(CSharpBinder.Binder).GetAssemblyPublicKeyToken();

            IgnoredAssemblies = AppDomain.CurrentDomain
                                         .GetAssemblies()
                                         .Where(assembly => {
                                             return assembly.IsNCopAssembly() ||
                                                    assembly.HasSamePublicKeyToken(objectPublicKeyToken) ||
                                                    assembly.HasSamePublicKeyToken(binderPublicKeyToken);
                                         })
                                         .ToSet();
        }

        public IEnumerable<Assembly> Assemblies { get; set; }

        public static ISet<Assembly> IgnoredAssemblies { get; private set; }
    }
}
