using NCop.Core.Mixin;
using NCop.Core.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeDefinitionWeaver : ITypeDefinitionWeaver
    {
        public MixinsTypeDefinitionWeaver(IEnumerable<MixinMap> mixinsMap) {
            MixinsMap = mixinsMap;
        }

        public IEnumerable<MixinMap> MixinsMap { get; private set; }

        public ITypeDefinition Weave() {
            throw new NotImplementedException();
        }
    }
}
