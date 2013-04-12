using NCop.Core;
using NCop.Core.Mixin;
using NCop.Core.Weaving;
using NCop.Mixins.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeWeaverBuilder : ITypeWeaverBuilder, IMixinMapBag, IMethodWeaverBuilderBag
    {
        private readonly Type _type = null;
        private readonly List<MixinMap> _mixinsMap = null;
        private readonly ITypeDefinitionFactory _typeDefinitionFactory = null;
        private readonly List<IMethodWeaverBuilder> _methodWeaversBuilders = null;

        public MixinsTypeWeaverBuilder(Type type, ITypeDefinitionFactory typeDefinitionFactory) {
            _type = type;
            _mixinsMap = new List<MixinMap>();
            _methodWeaversBuilders = new List<IMethodWeaverBuilder>();
            _typeDefinitionFactory = typeDefinitionFactory;
        }

        public void Add(MixinMap item) {
            _mixinsMap.Add(item);
        }

        public void Add(IMethodWeaverBuilder item) {
            _methodWeaversBuilders.Add(item);
        }

        public ITypeWeaver Build() {
            var methodWeavers = _methodWeaversBuilders.Select(methodBuilder => methodBuilder.Build());
            return new MixinsWeaverStrategy(_typeDefinitionFactory, methodWeavers);
        }
    }
}
