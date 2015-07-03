using NCop.Aspects.Weaving;
using NCop.IoC;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using System;

namespace NCop.Composite.Mixins.Weaving
{
    internal abstract class AbstractCompositeWeaverBuilder : AbstrcatMixinsTypeWeaverBuilder
    {
        protected readonly IAspectTypeDefinition typeDefinition = null;

        protected AbstractCompositeWeaverBuilder(Type type, IAspectTypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, registry) {
            this.typeDefinition = typeDefinition;
        }

        public override abstract ITypeWeaver Build();
    }
}
