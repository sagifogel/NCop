using NCop.IoC;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using System;

namespace NCop.Composite.Mixins.Weaving
{
    internal class CompositeMixinsWeaverBuilder : MixinsTypeWeaverBuilder, ICompositeMixinsTypeWeaverBuilder
    {
        public CompositeMixinsWeaverBuilder(Type type, ITypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, typeDefinition, registry) {
        }
    }
}
