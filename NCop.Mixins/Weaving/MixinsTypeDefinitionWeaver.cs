using NCop.Core;
using NCop.Core.Weaving;
using NCop.Mixins.Engine;
using System;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeDefinitionWeaver : ITypeDefinitionWeaver, ITypeDefinitionFactory
    {
        private readonly Type _contract = null;
        private readonly IMixinsMap _mixinsMap = null;
        private NCop.Core.Lazy<ITypeDefinition> _typeDefinitionFactory = null;

        public MixinsTypeDefinitionWeaver(Type contract, IMixinsMap mixinsMap) {
            _contract = contract;
            _mixinsMap = mixinsMap;
            _typeDefinitionFactory = new Core.Lazy<ITypeDefinition>(() => {
                return new MixinsTypeDefinition(_contract, _mixinsMap);
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
