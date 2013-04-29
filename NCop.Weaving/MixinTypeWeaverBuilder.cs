using System.Reflection.Emit;
using NCop.Core.Mixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Weaving
{
    public class MixinTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private MixinMap mixinMap = null;
        private readonly Type type = null;
        private readonly List<IMethodWeaver> _methodWeavers = new List<IMethodWeaver>();

        public MixinTypeWeaverBuilder(Type type) {
            this.type = type;
        }

        public void AddMixinTypeMap(MixinMap mixinMap) {
            this.mixinMap = mixinMap;
        }

        public void AddMethodWeaver(IMethodWeaver methodWeaver) {
            _methodWeavers.Add(methodWeaver);
        }

        public ITypeWeaver Build() {
            var typeDefinitionWeaver = new MixinTypeDefinitionWeaver(mixinMap);

            return new MixinWeaverStrategy(typeDefinitionWeaver, _methodWeavers);
        }
    }
}
