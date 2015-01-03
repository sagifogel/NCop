using System;

namespace NCop.Weaving
{
	public interface IWeavingSettings
	{
		Type ContractType { get; }
		ITypeDefinition TypeDefinition { get; }
	}
}
