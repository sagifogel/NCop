using NCop.Core.Mixin;
using NCop.Core.Weaving;
using NCop.Mixins.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private ISet<MixinMap> _mixinsMap = new HashSet<MixinMap>();
        private List<IMethodWeaver> _methodWeavers = new List<IMethodWeaver>();

        public void AddMixinTypeMap(MixinMap mixinMap) {
            _mixinsMap.Add(mixinMap);
        }

        public void AddMethodWeaver(IMethodWeaver methodWeaver) {
            _methodWeavers.Add(methodWeaver);
        }
        
        public ITypeWeaver Build() {
            var typeDefinitionWeaver = new MixinsTypeDefinitionWeaver(_mixinsMap);

            return new TypeWeaverStrategy(typeDefinitionWeaver, _methodWeavers);
        }
    }
}
