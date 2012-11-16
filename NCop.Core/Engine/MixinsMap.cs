using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Engine
{
    public class MixinsMap : Collection<MixinMap>, IMixinsMap
    {
        public MixinsMap() : base() { }

        public MixinsMap(IEnumerable<MixinMap> mixins) : base(mixins) { }
    }
}
