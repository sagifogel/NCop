using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Mixins.Engine
{
    public class MixinDefinition
    {
        public Type Type { get; private set; }
        public IAspectDefinitionCollection Aspects { get; private set; }
    }
}
