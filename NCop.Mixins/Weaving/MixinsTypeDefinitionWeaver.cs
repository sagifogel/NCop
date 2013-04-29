using NCop.Core;
using NCop.Weaving;
using NCop.Mixins.Engine;
using System;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeDefinitionWeaver : ITypeDefinitionWeaver, ITypeDefinitionFactory
    {
        private readonly Type contract = null;
        private readonly IMixinsMap mixinsMap = null;
        private NCop.Core.Lazy<ITypeDefinition> _typeDefinitionFactory = null;

        public MixinsTypeDefinitionWeaver(Type contract, IMixinsMap mixinsMap) {
            this.contract = contract;
            this.mixinsMap = mixinsMap;
            _typeDefinitionFactory = new Core.Lazy<ITypeDefinition>(() => {
                return new MixinsTypeDefinition(contract, mixinsMap);
            });
        }

        public Type Type { get; private set; }

        public ITypeDefinition Weave() {
            return _typeDefinitionFactory.Value;
        }

        public ITypeDefinition Resolve() {
            return Weave();
        }
    }
}
