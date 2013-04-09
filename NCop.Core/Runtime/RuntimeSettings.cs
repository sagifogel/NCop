using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;
using NCop.Core.Extensions;
using NCop.Core.Runtime;

namespace NCop.Core
{
    public class RuntimeSettings : IRuntimeSettings
    {
        protected IEnumerable<Assembly> ProtectedAssemblies = null;
        protected Lazy<IEnumerable<Assembly>> LazyAssemblies = null;

        public RuntimeSettings(IEnumerable<Assembly> assemblies = null) {
            ProtectedAssemblies = assemblies;
            LazyAssemblies = new Lazy<IEnumerable<Assembly>>(() => AssembliesInternal);
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
                                .Where(assembly => !IgnoredAssemblies.Instance.Contains(assembly));
            }
        }
    }
}
