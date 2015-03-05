using NCop.Core;
using NCop.Weaving;
using System;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeDefinitionWeaver : ITypeDefinitionWeaver
    {
        private readonly ITypeDefinition typeDefinition = null;

        public MixinsTypeDefinitionWeaver(Type contractType, ITypeMap mixinsMap) {
            Type = contractType;
            typeDefinition = new MixinsTypeDefinition(contractType, mixinsMap);
        }

        public Type Type { get; private set; }

        public ITypeDefinition Weave() {
            return typeDefinition;
        }
    }
}
