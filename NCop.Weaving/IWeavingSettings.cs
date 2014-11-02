using System;

namespace NCop.Weaving
{
	public interface IWeavingSettings
	{
		Type ContractType { get; }
		Type ImplementationType { get; }
		ITypeDefinition TypeDefinition { get; }
	}
}
