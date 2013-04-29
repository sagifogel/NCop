using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace NCop.Weaving
{
    internal sealed class NCopAssemblyBuilder
    {
        private static readonly string assemblyName = "NCop.Artifacts";
        private static readonly Lazy<AssemblyBuilder> assemblyBuilder = null;

        private NCopAssemblyBuilder() { }

        static NCopAssemblyBuilder() {
            assemblyBuilder = new Lazy<AssemblyBuilder>(() => {
                return AppDomain.CurrentDomain.DefineDynamicAssembly(
                    new AssemblyName(assemblyName),
                    AssemblyBuilderAccess.Run);
            });
        }

        internal static string AssemblyName {
            get {
                return assemblyName;
            }
        }

        internal static AssemblyBuilder Instance {
            get {
                return assemblyBuilder.Value;
            }
        }
    }
}