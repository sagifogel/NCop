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
    public class MixinsTypeWeaverBuilder : ITypeWeaverBuilder, IMixinMapBag, IMethodWeaverBag
    {
        private readonly Type _type = null;
        private readonly List<MixinMap> _mixinsMap = null;
        private readonly List<IMethodWeaver> _methodWeavers = null;

        public MixinsTypeWeaverBuilder(Type type) {
            _type = type;
            _mixinsMap = new List<MixinMap>();
            _methodWeavers = new List<IMethodWeaver>();
        }
        
        public void Add(MixinMap item) {
            _mixinsMap.Add(item);
        }

        public void Add(IMethodWeaver item) {
            _methodWeavers.Add(item);
        }

        public ITypeWeaver Build() {
            return new MixinsWeaverStrategy(_type, new MixinsMap(_mixinsMap), _methodWeavers);
        }
    }
}
