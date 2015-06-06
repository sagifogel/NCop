using NCop.Aspects.Weaving;
using NCop.Core;
using NCop.IoC;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class AtomMixinsWeaverStrategy : MixinsWeaverStrategy
    {
        internal AtomMixinsWeaverStrategy(IAspectTypeDefinition typeDefinition, TypeMap mixin, IEnumerable<IMethodWeaver> methodWeavers, INCopDependencyAwareRegistry registry)
            : base(typeDefinition, new TypeMapSet { mixin }, methodWeavers, registry) {
        }

        protected override void EmitConstructorBody(ILGenerator ilGenerator) {
            var compositeTypeDefinition = typeDefinition as IAspectTypeDefinition;

            base.EmitConstructorBody(ilGenerator);
        }
    }
}
