using NCop.Core;
using System;

namespace NCop.Weaving
{
    public abstract class AbstractTypeDefinitionWeaver : ITypeDefinitionWeaver
    {   
        protected readonly ITypeMap mixinsMap = null;
        
        protected AbstractTypeDefinitionWeaver(Type contractType, ITypeMap mixinsMap) {
            Type = contractType;
            this.mixinsMap = mixinsMap;
        }

        public Type Type { get; private set; }

        public abstract ITypeDefinition Weave();
    }
}
