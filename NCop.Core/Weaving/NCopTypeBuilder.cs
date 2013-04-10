using NCop.Core.Weaving.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
	public static class NCopTypeBuilder
	{
		public static TypeBuilder DefineType(this Type interfaceType, TypeAttributes attr, IEnumerable<Type> interfaces, string name = null) {
			name = name ?? string.Format("{0}.{1}", NCopAssemblyBuilder.AssemblyName, interfaceType.Name);

			return NCopModuleBuilder.Instance.DefineType(name, attr, null, interfaces.ToArray());
		}

		public static FieldBuilder DefineField(this TypeBuilder typeBuilder, Type fieldType, FieldAttributes fieldAttributes, string name = null) {
			name = name ?? string.Format("{0}.{1}", NCopAssemblyBuilder.AssemblyName, fieldType.Name);

			return typeBuilder.DefineField(name, fieldType, fieldAttributes);
		}
	}
}
