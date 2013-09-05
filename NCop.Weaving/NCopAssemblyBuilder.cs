using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using NCop.Core.Extensions;

namespace NCop.Weaving
{
    internal sealed class NCopAssemblyBuilder : IBuilder<AssemblyBuilder>
    {
        private string assemblyName = null;
        private AssemblyBuilder builder = null;
        private static readonly string assemblyNamePrefix = "NCop.Artifacts";

        public NCopAssemblyBuilder() {
            assemblyName = "{0}<{1}>".Fmt(assemblyNamePrefix, Guid.NewGuid().ToString());
        }

        internal string AssemblyName {
            get {
                return assemblyName;
            }
        }

        public AssemblyBuilder Build() {
            return builder ?? (builder = BuildInternal());
        }

        private AssemblyBuilder BuildInternal() {
            var assemblyName = new AssemblyName(AssemblyName);
            return AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        }
    }
}