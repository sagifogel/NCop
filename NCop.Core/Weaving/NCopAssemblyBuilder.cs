using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace NCop.Core.Weaving
{
    internal sealed class NCopAssemblyBuilder
    {
        private static readonly string _assemblyName = "NCop.Artifacts";
        private static readonly Lazy<AssemblyBuilder> _assemblyBuilder = null;

        private NCopAssemblyBuilder() { }

        static NCopAssemblyBuilder() {
            _assemblyBuilder = new Lazy<AssemblyBuilder>(() => {
                return AppDomain.CurrentDomain.DefineDynamicAssembly(
                    new AssemblyName(_assemblyName),
                    AssemblyBuilderAccess.Run);
            });
        }

        internal static string AssemblyName {
            get {
                return _assemblyName;
            }
        }

        internal static AssemblyBuilder Instance {
            get {
                return _assemblyBuilder.Value;
            }
        }
    }
}