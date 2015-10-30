using NCop.Aspects.Weaving;
using NCop.Core;
using NCop.IoC;
using NCop.Weaving;
using System;
using System.Threading;
using NCop.Core.Extensions;
using NCop.Composite.Framework;

namespace NCop.Composite.Weaving
{
    internal class AtomCompositeMixinsWeaverBuilder : AbstractCompositeWeaverBuilder, ICompositeMixinsTypeWeaverBuilder
    {
        private TypeMap mixin = null;

        public AtomCompositeMixinsWeaverBuilder(Type type, IAspectTypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, typeDefinition, registry) {
        }

        public override ITypeWeaver Build() {
            AddEventWeavers();
            AddMethodWeavers();
            AddPropertyWeavers();

            if (mixin.ConcreteType.IsNotDefined<IgnoreRegistrationAttribute>()) {
                registry.Register(mixin);
            }

            return new AtomMixinsWeaverStrategy(typeDefinition, mixin, methodWeavers, registry);
        }

        public override void Add(TypeMap item) {
            Interlocked.CompareExchange(ref mixin, item, null);
        }
    }
}
