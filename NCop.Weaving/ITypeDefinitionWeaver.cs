using System;

namespace NCop.Weaving
{
    public interface ITypeDefinitionWeaver
    {
	    Type Type { get; }
        ITypeDefinition Weave();
    }
}
