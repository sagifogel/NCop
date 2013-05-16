using NCop.Core;
using NCop.Weaving;
using NCop.Mixins.Engine;
using System;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeDefinitionWeaver : ITypeDefinitionWeaver, ITypeDefinitionFactory
    {
        private readonly Type contractType = null;
        private readonly IMixinsMap mixinsMap = null;
        private NCop.Core.Lazy<ITypeDefinition> typeDefinitionFactory = null;

        public MixinsTypeDefinitionWeaver(Type contractType, IMixinsMap mixinsMap) {
            this.contractType = contractType;
            this.mixinsMap = mixinsMap;
            typeDefinitionFactory = new Core.Lazy<ITypeDefinition>(() => {
                return new MixinsTypeDefinition(contractType, mixinsMap);
            });
        }

        public Type Type { get; private set; }

        public ITypeDefinition Weave() {
            return typeDefinitionFactory.Value;
        }

        public ITypeDefinition Resolve() {
            return Weave();
        }
    }
}
