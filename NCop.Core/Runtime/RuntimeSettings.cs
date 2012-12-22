using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;
using NCop.Core.Extensions;

namespace NCop.Core
{
    public class RuntimeSettings : IRuntimeSettings
    {
        protected IEnumerable<Assembly> ProtectedAssemblies = null;
        protected static Lazy<IEnumerable<Assembly>> LazyAssemblies = null;

        static RuntimeSettings() {
            var objectPublicKeyToken = typeof(object).GetAssemblyPublicKeyToken();
            var binderPublicKeyToken = typeof(CSharpBinder.Binder).GetAssemblyPublicKeyToken();

            LazyAssemblies = new Lazy<IEnumerable<Assembly>>(() => AssembliesInternal);
            IgnoredAssemblies = AppDomain.CurrentDomain
                                         .GetAssemblies()
                                         .Where(assembly => {
                                             return assembly.IsNCopAssembly() ||
                                                    assembly.HasSamePublicKeyToken(objectPublicKeyToken) ||
                                                    assembly.HasSamePublicKeyToken(binderPublicKeyToken);
                                         })
                                         .ToSet();
        }

        public RuntimeSettings(IEnumerable<Assembly> assemblies = null) {
            ProtectedAssemblies = assemblies;
        }

        public IEnumerable<Assembly> Assemblies {
            get {
                return ProtectedAssemblies ?? LazyAssemblies.Value;
            }
        }

        private static IEnumerable<Assembly> AssembliesInternal {
            get {
                return AppDomain.CurrentDomain
                                .GetAssemblies()
                                .Where(assembly => !IgnoredAssemblies.Contains(assembly));
            }
        }

        public static ISet<Assembly> IgnoredAssemblies { get; private set; }
    }
}
