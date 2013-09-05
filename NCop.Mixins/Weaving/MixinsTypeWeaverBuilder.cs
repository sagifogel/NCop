using NCop.Core;
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
        private readonly List<TypeMap> mixinsMap = null;
        private readonly ITypeDefinitionFactory typeDefinitionFactory = null;
        private readonly List<IMethodWeaverBuilder> methodWeaversBuilders = null;
        private readonly List<IPropertyWeaverBuilder> propertyWeaversBuilders = null;

        public MixinsTypeWeaverBuilder(Type type, ITypeDefinitionFactory typeDefinitionFactory, IRegistry registry) {
            this.type = type;
            this.registry = registry;
            mixinsMap = new List<TypeMap>();
            methodWeaversBuilders = new List<IMethodWeaverBuilder>();
            propertyWeaversBuilders = new List<IPropertyWeaverBuilder>();
            this.typeDefinitionFactory = typeDefinitionFactory;
        }

        public void Add(TypeMap item) {
            mixinsMap.Add(item);
        }

        public void Add(IMethodWeaverBuilder item) {
            methodWeaversBuilders.Add(item);
        }

        public void Add(IPropertyWeaverBuilder item) {
            propertyWeaversBuilders.Add(item);
        }

        public ITypeWeaver Build() {
            var methodWeavers = new List<IMethodWeaver>();

            methodWeaversBuilders.ForEach(methodBuilder => {
                methodWeavers.Add(methodBuilder.Build());
            });

            propertyWeaversBuilders.ForEach(propertyBuilder => {
                var propertyWeaver = propertyBuilder.Build();

                if (propertyWeaver.CanRead) {
                    methodWeavers.Add(propertyWeaver.GetGetMethod());
                }

                if (propertyWeaver.CanWrite) {
                    methodWeavers.Add(propertyWeaver.GetSetMethod());
                }
            });

            mixinsMap.ForEach(map => {
                if (!registry.Contains(map.ContractType)) {
                    registry.Register(map.ImplementationType, map.ContractType);
                }
            });

            return new MixinsWeaverStrategy(typeDefinitionFactory, methodWeavers, registry);
        }
    }
}
