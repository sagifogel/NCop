using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Weaving
{
	public class MethodWeavingSettings : IMethodWeavingSettings
	{
		public MethodWeavingSettings(MethodInfo methodInfoImpl, Type implementationType, Type contractType, ITypeDefinition typeDefinition) {
			ContractType = contractType;
			MethodInfoImpl = methodInfoImpl;
			TypeDefinition = typeDefinition;
			ImplementationType = implementationType;
		}

		public Type ContractType { get; private set; }
		public Type ImplementationType { get; private set; }
		public MethodInfo MethodInfoImpl { get; private set; }
		public ITypeDefinition TypeDefinition { get; private set; }
	}
}
