using NCop.Core.Extensions;
using NCop.Core.Runtime;
using NCop.IoC;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Composite.Runtime
{
    public class CompositeRuntimeSettings : IRuntimeSettings
    {
        protected IEnumerable<Type> types = null;
        protected IEnumerable<Assembly> assemblies = null;
        private readonly static RuntimeSettings runtimeSettings = null;
        public static CompositeRuntimeSettings Empty = new CompositeRuntimeSettings();

        static CompositeRuntimeSettings() {
            runtimeSettings = new RuntimeSettings();
        }

        public IEnumerable<Type> Types { get; set; }
        public IEnumerable<Assembly> Assemblies { get; set; }
        public INCopDependencyContainerAdapter DependencyContainerAdapter { get; set; }
    }
}
