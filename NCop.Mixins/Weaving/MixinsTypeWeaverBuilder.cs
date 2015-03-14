using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.Mixins.Engine;
using NCop.Weaving;
using System;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeWeaverBuilder : AbstractTypeWeaverBuilder, IMixinMapBag
    {
        protected readonly TypeMapSet mixinsMap = null;
        protected readonly INCopDependencyAwareRegistry registry = null;

        public MixinsTypeWeaverBuilder(Type type, ITypeDefinition typeDefinition, INCopDependencyAwareRegistry registry)
            : base(type, typeDefinition) {
            this.registry = registry;
            mixinsMap = new TypeMapSet();
        }

        public void Add(TypeMap item) {
            mixinsMap.Add(item);
        }

        public override ITypeWeaver Build() {
            AddMethodWeavers();
            AddPropertyWeavers();
            mixinsMap.ForEach(map => registry.Register(map.ImplementationType, map.ContractType));

            return new MixinsWeaverStrategy(typeDefinition, mixinsMap, methodWeavers, registry);
        }
    }
}
