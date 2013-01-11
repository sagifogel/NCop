using NCop.Core.Mixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
    public class MixinTypeDefinitionWeaver : ITypeDefinitionWeaver
    {
        public MixinTypeDefinitionWeaver(MixinMap mixinMap) {
            MixinMap = mixinMap;
        }

        public MixinMap MixinMap { get; private set; }

        public ITypeDefinition Weave() {
            throw new NotImplementedException();
        }
    }
}
