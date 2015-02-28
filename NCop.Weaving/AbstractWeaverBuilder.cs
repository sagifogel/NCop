using System;

namespace NCop.Weaving
{
    public abstract class AbstractWeaverBuilder
    {
        protected readonly Type contractType = null;
        protected readonly ITypeDefinition typeDefinition = null;

        protected AbstractWeaverBuilder(Type contractType, ITypeDefinition typeDefinition) {
            this.contractType = contractType;
            this.typeDefinition = typeDefinition;
        }
    }
}
