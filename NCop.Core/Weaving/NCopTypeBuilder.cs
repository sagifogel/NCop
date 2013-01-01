using NCop.Core.Weaving.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving.Proxies
{
    public static class NCopTypeBuilder
    {
        public static TypeBuilder DefineType(Type decoratedType, TypeAttributes attr, Type[] interfaces, string name = null) {
            name = name ?? string.Format("{0}.Proxies.{1}", NCopAssemblyBuilder.AssemblyName, decoratedType.FullName);

            return NCopModuleBuilder.Instance.DefineType(name, attr, null, interfaces);
        }
    }
}
