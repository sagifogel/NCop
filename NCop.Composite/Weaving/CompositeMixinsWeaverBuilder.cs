using NCop.Aspects.Weaving;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.Weaving;
using System;

namespace NCop.Composite.Weaving
{
    internal class CompositeMixinsWeaverBuilder : AbstractCompositeWeaverBuilder, ICompositeMixinsTypeWeaverBuilder
    {
        public CompositeMixinsWeaverBuilder(Type type, IAspectTypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, typeDefinition, registry) {
        }

        public override ITypeWeaver Build() {
            AddEventWeavers();
            AddMethodWeavers();
            AddPropertyWeavers();

            mixinsMap.ForEach(map => {
                if (map.ConcreteType.IsNotDefined<IgnoreRegistrationAttribute>()) {
                    var name = Guid.NewGuid().ToString();

                    registry.Register(map.CloneWithName(name));
                }
            });

            return new CompositeWeavingStrategy(typeDefinition, mixinsMap, methodWeavers, registry);
        }
    }
}
