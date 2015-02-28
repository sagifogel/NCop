using System;

namespace NCop.Weaving
{
	public class WeavingSettingsImpl : IWeavingSettings
	{
		public WeavingSettingsImpl(Type contractType, ITypeDefinition typeDefinition) {
			ContractType = contractType;
			TypeDefinition = typeDefinition;
		}

		public Type ContractType { get; private set; }
		public ITypeDefinition TypeDefinition { get; private set; }
	}
}
