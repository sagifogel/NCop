using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Engine
{
    public class MixinDefinition
    {
        public Type Type { get; private set; }
        public IAspectDefinitionCollection Aspects { get; private set; }
    }
}
