using NCop.Aspects.Weaving;
using NCop.Core;
using NCop.IoC;
using NCop.Weaving;
using System.Collections.Generic;

namespace NCop.Composite.Weaving
{
    internal class AtomMixinsWeaverStrategy : CompositeWeavingStrategy
    {
        internal AtomMixinsWeaverStrategy(IAspectTypeDefinition typeDefinition, TypeMap mixin, IEnumerable<IMethodWeaver> methodWeavers, INCopDependencyAwareRegistry registry)
            : base(typeDefinition, new TypeMapSet { mixin }, methodWeavers, registry) {
        }
    }
}
