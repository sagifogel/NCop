using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.Mixins.Engine;
using NCop.Weaving;
using System;
using System.Collections.Generic;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeWeaverBuilder : AbstractTypeWeaverBuilder, IMixinMapBag
    {
        protected readonly INCopRegistry registry = null;
        protected readonly ISet<TypeMap> mixinsMap = null;

        public MixinsTypeWeaverBuilder(Type type, ITypeDefinition typeDefinition, INCopRegistry registry)
            : base(type, typeDefinition) {
            this.registry = registry;
            mixinsMap = new HashSet<TypeMap>();
        }

        public void Add(TypeMap item) {
            mixinsMap.Add(item);
        }

        public override void AddMethodWeavers() {
            base.AddMethodWeavers();

            mixinsMap.ForEach(map => {
                registry.Register(map.ImplementationType, map.ContractType);
            });
        }

        public override ITypeWeaver CreateTypeWeaver() {
            return new MixinsWeaverStrategy(typeDefinition, mixinsMap, methodWeavers, registry);
        }
    }
}
