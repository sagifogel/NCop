using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core;

namespace NCop.Weaving
{
    public class MixinTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private TypeMap mixinMap = null;
        private readonly Type type = null;
        private readonly List<IMethodWeaver> methodWeavers = new List<IMethodWeaver>();

        public MixinTypeWeaverBuilder(Type type) {
            this.type = type;
        }

        public void AddMixinTypeMap(TypeMap mixinMap) {
            this.mixinMap = mixinMap;
        }

        public void AddMethodWeaver(IMethodWeaver methodWeaver) {
            methodWeavers.Add(methodWeaver);
        }

        public ITypeWeaver Build() {
            var typeDefinitionWeaver = new MixinTypeDefinitionWeaver(mixinMap);

            return new MixinWeaverStrategy(typeDefinitionWeaver, methodWeavers);
        }
    }
}
