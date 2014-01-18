using System;
using System.Reflection.Emit;
using System.Threading;
using NCop.Core.Extensions;
using Lib = NCop.Core.Lib;

namespace NCop.Weaving
{
    public sealed class NCopModuleBuilder
    {
        private ModuleBuilder moduleBuilder = null;
        private static readonly object syncLock = new object();
        private static Lib.Lazy<NCopModuleBuilder> lazyNCopModuleBuilder = NewNCopModuleBuilder();

        public NCopModuleBuilder() {
            moduleBuilder = NewModule();
        }

        public static ModuleBuilder Instance {
            get {
                return lazyNCopModuleBuilder.Value.moduleBuilder;
            }
        }

        private static ModuleBuilder NewModule() {
            var assemblyBuilder = new NCopAssemblyBuilder();
            string assemblyName = "{0}.dll".Fmt(assemblyBuilder.AssemblyName);

            return assemblyBuilder.Build().DefineDynamicModule(assemblyName, false);
        }

        public static void Flush() {
            lock (syncLock) {
                lazyNCopModuleBuilder = NewNCopModuleBuilder();
            }
        }

        private static Lib.Lazy<NCopModuleBuilder> NewNCopModuleBuilder() {
            return new Lib.Lazy<NCopModuleBuilder>(() => new NCopModuleBuilder());
        }
    }
}