using NCop.Composite.Weaving;
using NCop.Core;
using NCop.IoC;
using NCop.Weaving;
using System;
using System.Threading;

namespace NCop.Composite.Mixins.Weaving
{
    internal class AtomCompositeMixinsWeaverBuilder : AbstractTypeWeaverBuilder, ICompositeMixinsTypeWeaverBuilder
    {
        private TypeMap mixin = null;
        protected readonly INCopDependencyAwareRegistry registry = null;
        private readonly string atomIdentifier = Guid.NewGuid().ToString();

        public AtomCompositeMixinsWeaverBuilder(Type type, ITypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, typeDefinition) {
            this.registry = registry;
        }

        public override ITypeWeaver Build() {
            AddEventWeavers();
            AddMethodWeavers();
            AddPropertyWeavers();
            registry.Register(mixin.ImplementationType, mixin.ContractType, name: atomIdentifier);
            
            return new AtomMixinsWeaverStartegy(typeDefinition, mixin, methodWeavers, registry);
        }

        public void Add(TypeMap item) {
            Interlocked.CompareExchange(ref mixin, item, null);
        }
    }
}
