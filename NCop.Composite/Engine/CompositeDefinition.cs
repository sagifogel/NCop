using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Engine
{
    public class CompositeDefinition
    {
        public Type Type { get; private set; }
        public IMixinDefinitionCollection Mixins { get; private set; }
    }
}
