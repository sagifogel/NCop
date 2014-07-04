using NCop.Composite.Weaving;
using NCop.Core;
using NCop.IoC;
using NCop.Mixins.Engine;
using NCop.Mixins.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public override void AddMethodWeavers() {
            base.AddMethodWeavers();
            registry.Register(mixin.ImplementationType, mixin.ContractType, name: atomIdentifier);
        }

        public override ITypeWeaver CreateTypeWeaver() {
            return new AtomMixinsWeaverStartegy(typeDefinition, mixin, methodWeavers, registry);
        }

        public void Add(TypeMap item) {
            Interlocked.CompareExchange(ref mixin, item, null);
        }
    }
}
