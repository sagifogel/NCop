using System;
using System.Reflection.Emit;
using System.Threading;

namespace NCop.Weaving
{
    internal sealed class NCopModuleBuilder
    {
        private static readonly Lazy<ModuleBuilder> moduleBuilder = null;

        private NCopModuleBuilder() { }

        static NCopModuleBuilder() {
            moduleBuilder = new Lazy<ModuleBuilder>(CreateAssemblyBuilder);
        }

        internal static ModuleBuilder Instance {
            get {
                return moduleBuilder.Value;
            }
        }

        private static ModuleBuilder CreateAssemblyBuilder() {
            var assemblyBuilder = NCopAssemblyBuilder.Instance;
            string assemblyName = string.Format("{0}.dll", NCopAssemblyBuilder.AssemblyName);

            return assemblyBuilder.DefineDynamicModule(assemblyName, false);
        }
    }
}