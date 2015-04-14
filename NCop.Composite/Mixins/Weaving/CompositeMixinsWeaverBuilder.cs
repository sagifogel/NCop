using System;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.Mixins.Weaving;
using NCop.Weaving;

namespace NCop.Composite.Mixins.Weaving
{
    internal class CompositeMixinsWeaverBuilder : AbstrcatMixinsTypeWeaverBuilder, ICompositeMixinsTypeWeaverBuilder
    {
        public CompositeMixinsWeaverBuilder(Type type, ITypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, typeDefinition, registry) {
        }

        public override ITypeWeaver Build() {
            AddMethodWeavers();
            AddPropertyWeavers();

            mixinsMap.ForEach(map => {
                if (map.ImplementationType.IsNotDefined<IgnoreRegistrationAttribute>()) {
                    registry.Register(map.ImplementationType, map.ContractType, name: Guid.NewGuid().ToString());
                }
            });

            return new MixinsWeaverStrategy(typeDefinition, mixinsMap, methodWeavers, registry);
        }
    }
}
