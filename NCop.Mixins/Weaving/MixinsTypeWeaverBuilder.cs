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
    public class MixinsTypeWeaverBuilder : ITypeWeaverBuilder, IMixinMapBag, IMethodWeaverBuilderBag
    {
        private readonly Type type = null;
        private readonly IRegistry registry = null;
        private readonly List<MixinMap> mixinsMap = null;
        private readonly ITypeDefinitionFactory typeDefinitionFactory = null;
        private readonly List<IMethodWeaverBuilder> methodWeaversBuilders = null;

        public MixinsTypeWeaverBuilder(Type type, ITypeDefinitionFactory typeDefinitionFactory, IRegistry registry) {
            this.type = type;
            this.registry = registry;
            mixinsMap = new List<MixinMap>();
            this.methodWeaversBuilders = new List<IMethodWeaverBuilder>();
            this.typeDefinitionFactory = typeDefinitionFactory;
        }

        public void Add(MixinMap item) {
            mixinsMap.Add(item);
        }

        public void Add(IMethodWeaverBuilder item) {
            methodWeaversBuilders.Add(item);
        }

        public ITypeWeaver Build() {
            var methodWeavers = methodWeaversBuilders.Select(methodBuilder => methodBuilder.Build());
            return new MixinsWeaverStrategy(typeDefinitionFactory, methodWeavers, registry);
        }
    }
}
