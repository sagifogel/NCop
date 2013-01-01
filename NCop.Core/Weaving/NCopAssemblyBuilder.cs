using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace NCop.Core.Weaving.Proxies
{
    internal sealed class NCopAssemblyBuilder
    {
        private static readonly string _assemblyName = null;
        private static readonly Lazy<AssemblyBuilder> _assemblyBuilder = null;

        private NCopAssemblyBuilder() { }

        static NCopAssemblyBuilder() {
            _assemblyName = string.Format("{0}.Proxies", Path.GetFileNameWithoutExtension(typeof(NCopAssemblyBuilder).Namespace));
            _assemblyBuilder = new Lazy<AssemblyBuilder>(CreateAssemblyBuilder);
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

        private static AssemblyBuilder CreateAssemblyBuilder() {
            var name = new AssemblyName(_assemblyName);

            return AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
        }
    }
}