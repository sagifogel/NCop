using NCop.Core;
using System;

namespace NCop.Weaving
{
    public abstract class AbstractTypeDefinitionWeaver : ITypeDefinitionWeaver
    {   
        protected readonly ITypeMapCollection mixinsMap = null;
        
        protected AbstractTypeDefinitionWeaver(Type contractType, ITypeMapCollection mixinsMap) {
            Type = contractType;
            this.mixinsMap = mixinsMap;
        }

        public Type Type { get; private set; }

        public abstract ITypeDefinition Weave();
    }
}
