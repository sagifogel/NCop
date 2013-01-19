using System.Reflection.Emit;
using NCop.Core.Mixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MixinTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private MixinMap _mixinMap = null;
        private readonly Type _type = null;
        private readonly List<IMethodWeaver> _methodWeavers = new List<IMethodWeaver>();

        public MixinTypeWeaverBuilder(Type type) {
            _type = type;
        }

        public void AddMixinTypeMap(MixinMap mixinMap) {
            _mixinMap = mixinMap;
        }

        public void AddMethodWeaver(IMethodWeaver methodWeaver) {
            _methodWeavers.Add(methodWeaver);
        }

        public ITypeWeaver Build() {
            var typeDefinitionWeaver = new MixinTypeDefinitionWeaver(_mixinMap);

            return new MixinWeaverStrategy(typeDefinitionWeaver, _methodWeavers);
        }
    }
}
