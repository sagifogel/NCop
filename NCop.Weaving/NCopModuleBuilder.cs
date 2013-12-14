using System;
using System.Reflection.Emit;
using System.Threading;
using NCop.Core.Extensions;
using Lib = NCop.Core.Lib;

namespace NCop.Weaving
{
    internal sealed class NCopModuleBuilder
    {
        private readonly ModuleBuilder moduleBuilder = null;
        private static Lib.Lazy<NCopModuleBuilder> lazyNCopModuleBuilder = new Lib.Lazy<NCopModuleBuilder>(() => new NCopModuleBuilder());

        public NCopModuleBuilder() {
            var assemblyBuilder = new NCopAssemblyBuilder();
            string assemblyName = "{0}.dll".Fmt(assemblyBuilder.AssemblyName);

            moduleBuilder = assemblyBuilder.Build().DefineDynamicModule(assemblyName, false); ;
        }

        public static ModuleBuilder Instance {
            get {
                return lazyNCopModuleBuilder.Value.moduleBuilder;
            }
        }
    }
}