using NCop.Core;
using NCop.Weaving;
using System;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeDefinitionWeaver : AbstractTypeDefinitionWeaver
    {
        private readonly ITypeDefinitionIntilaizer typeDefinitionInitializer = null;

        public MixinsTypeDefinitionWeaver(Type contractType, ITypeMapCollection mixinsMap)
            : base(contractType, mixinsMap) {
            typeDefinitionInitializer = new MixinsTypeDefinition(Type, mixinsMap);
        }

        public override ITypeDefinition Weave() {
            return typeDefinitionInitializer.Initialize();
        }
    }
}
