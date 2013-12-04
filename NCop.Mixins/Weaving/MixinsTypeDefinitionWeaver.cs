using NCop.Core;
using NCop.Weaving;
using NCop.Mixins.Engine;
using System;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeDefinitionWeaver : ITypeDefinitionWeaver
    {
        private readonly Type contractType = null;
        private readonly ITypeMap mixinsMap = null;
        private readonly ITypeDefinition typeDefinition = null;

        public MixinsTypeDefinitionWeaver(Type contractType, ITypeMap mixinsMap) {
            this.contractType = contractType;
            this.mixinsMap = mixinsMap;
            typeDefinition = new MixinsTypeDefinition(contractType, mixinsMap);
        }

        public Type Type { get; private set; }

        public ITypeDefinition Weave() {
            return typeDefinition;
        }
    }
}
