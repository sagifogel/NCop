using NCop.Core.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Engine
{
    public class MixinDefinition
    {
        public Type Type { get; private set; }
        public IAspectDefinitionCollection Aspects { get; private set; }
    }
}
