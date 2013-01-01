using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MixinsTypeWeaver : ITypeWeaver
    {
        private IEnumerable<IMixinTypeWeaver> _typeWeavers = null;

        public MixinsTypeWeaver(IEnumerable<IMixinTypeWeaver> typeWeavers) {
            _typeWeavers = typeWeavers;
        }

        public TypeBuilder TypeBuilder { get; private set; }

        void IWeaver.Weave() {
            var interfaces = _typeWeavers.Select(weaver => weaver.Interface);
        }
    }
}
