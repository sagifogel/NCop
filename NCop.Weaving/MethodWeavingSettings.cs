using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Weaving
{
	public class MethodWeavingSettings : IWeavingSettings
	{
		public MethodWeavingSettings(Type contractType, ITypeDefinition typeDefinition) {
			ContractType = contractType;
			TypeDefinition = typeDefinition;
		}

		public Type ContractType { get; private set; }
		public ITypeDefinition TypeDefinition { get; private set; }
	}
}
