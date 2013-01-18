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
    public class MixinsTypeWeaverBuilder : ITypeWeaverBuilder
    {
        private readonly Type _type = null;
        private readonly List<MixinMap> _mixinsMap = null;
        private readonly List<IMethodWeaver> _methodWeavers = null;

        public MixinsTypeWeaverBuilder(Type type) {
            _type = type;
            _mixinsMap = new List<MixinMap>();
            _methodWeavers = new List<IMethodWeaver>();
        }

        public void AddMixinTypeMap(MixinMap mixinMap) {
            _mixinsMap.Add(mixinMap);
        }

        public void AddMethodWeaver(IMethodWeaver methodWeaver) {
            _methodWeavers.Add(methodWeaver);
        }
        
        public ITypeWeaver Build() {
            return new MixinsWeaverStrategy(_type, new MixinsMap(_mixinsMap), _methodWeavers);
        }
    }
}
