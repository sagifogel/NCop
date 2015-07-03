using NCop.Composite.Engine;
using NCop.Core;
using NCop.Weaving;
using System;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeDefinitionWeaver : AbstractTypeDefinitionWeaver
    {
        private readonly ITypeDefinitionIntilaizer typeDefinitionInitializer = null;

        internal CompositeTypeDefinitionWeaver(Type contractType, ITypeMap mixinsMap, ICompositeMemberCollection compositeMemberCollection)
            : base(contractType, mixinsMap) {
            typeDefinitionInitializer = new CompositeTypeDefinition(Type, mixinsMap, compositeMemberCollection);
        }

        public override ITypeDefinition Weave() {
            return typeDefinitionInitializer.Initialize();
        }
    }
}
