using NCop.Aspects.Weaving;
using NCop.Composite.Weaving;
using NCop.Core;
using NCop.IoC;
using NCop.Weaving;
using System;
using System.Threading;

namespace NCop.Composite.Mixins.Weaving
{
    internal class AtomCompositeMixinsWeaverBuilder : AbstractCompositeWeaverBuilder, ICompositeMixinsTypeWeaverBuilder
    {
        private TypeMap mixin = null;
        private readonly string atomIdentifier = Guid.NewGuid().ToString();

        public AtomCompositeMixinsWeaverBuilder(Type type, IAspectTypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, typeDefinition, registry) {
        }

        public override ITypeWeaver Build() {
            AddEventWeavers();
            AddMethodWeavers();
            AddPropertyWeavers();
            registry.Register(mixin.ImplementationType, mixin.ContractType, name: atomIdentifier);

            return new AtomMixinsWeaverStrategy(typeDefinition, mixin, methodWeavers, registry);
        }

        public override void Add(TypeMap item) {
            Interlocked.CompareExchange(ref mixin, item, null);
        }
    }
}
