using System;
using System.Reflection.Emit;
using System.Threading;
using NCop.Core.Extensions;

namespace NCop.Weaving
{
    internal sealed class NCopModuleBuilder : IBuilder<ModuleBuilder>
    {
        public ModuleBuilder Build() {
            var assemblyBuilder = new NCopAssemblyBuilder();
            string assemblyName = "{0}.dll".Fmt(assemblyBuilder.AssemblyName);

            return assemblyBuilder.Build().DefineDynamicModule(assemblyName, false);
        }
    }
}