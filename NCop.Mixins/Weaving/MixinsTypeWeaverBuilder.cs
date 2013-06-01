using NCop.Core;
using NCop.Core.Mixin;
using NCop.Weaving;
using NCop.Mixins.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.IoC;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeWeaverBuilder : ITypeWeaverBuilder, IMixinMapBag, IMethodWeaverBuilderBag, IPropertyWeaverBag
    {
        private readonly Type type = null;
        private readonly IRegistry registry = null;
        private readonly List<MixinMap> mixinsMap = null;
        private readonly ITypeDefinitionFactory typeDefinitionFactory = null;
        private readonly List<IMethodWeaverBuilder> methodWeaversBuilders = null;
        private readonly List<IPropertyWeaverBuilder> propertyWeaversBuilders = null;

        public MixinsTypeWeaverBuilder(Type type, ITypeDefinitionFactory typeDefinitionFactory, IRegistry registry) {
            this.type = type;
            this.registry = registry;
            mixinsMap = new List<MixinMap>();
            methodWeaversBuilders = new List<IMethodWeaverBuilder>();
            propertyWeaversBuilders = new List<IPropertyWeaverBuilder>();
            this.typeDefinitionFactory = typeDefinitionFactory;
        }

        public void Add(MixinMap item) {
            mixinsMap.Add(item);
        }

        public void Add(IMethodWeaverBuilder item) {
            methodWeaversBuilders.Add(item);
        }
        
        public void Add(IPropertyWeaverBuilder item) {
            propertyWeaversBuilders.Add(item);
        }

        public ITypeWeaver Build() {
            var methodWeavers = methodWeaversBuilders.Select(methodBuilder => methodBuilder.Build());

            mixinsMap.ForEach(map => {
                if (!registry.Contains(map.ContractType)) {
                    registry.Register(map.ImplementationType, map.ContractType);
                }
            });

            return new MixinsWeaverStrategy(typeDefinitionFactory, methodWeavers, registry);
        }

       
    }
}
