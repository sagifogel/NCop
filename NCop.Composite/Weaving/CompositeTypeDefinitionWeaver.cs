using NCop.Core;
using NCop.Weaving;
using System;
using System.Collections.Generic;

namespace NCop.Composite.Weaving
{
    internal class CompositeTypeDefinitionWeaver : AbstractTypeDefinitionWeaver
    {
        private readonly ITypeDefinitionIntilaizer typeDefinitionInitializer = null;

        internal CompositeTypeDefinitionWeaver(Type contractType, ITypeMap mixinsMap)
            : base(contractType, mixinsMap) {
            typeDefinitionInitializer = new CompositeTypeDefinition(Type, mixinsMap);
        }

        public override ITypeDefinition Weave() {
            return typeDefinitionInitializer.Initialize();
        }
    }
}
