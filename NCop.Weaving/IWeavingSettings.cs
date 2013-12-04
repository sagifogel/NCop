using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Weaving
{
	public interface IWeavingSettings
	{
		Type ContractType { get; }
		Type ImplementationType { get; }
		MethodInfo MethodInfoImpl { get; }
		ITypeDefinition TypeDefinition { get; }
	}
}
