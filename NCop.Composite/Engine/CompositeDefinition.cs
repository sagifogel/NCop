using System;
using NCop.Aspects.Aspects;
using NCop.Mixins.Engine;

namespace NCop.Composite.Engine
{
    public class CompositeDefinition
    {
        public Type Type { get; private set; }
        public IMixinDefinitionCollection Mixins { get; private set; }
		public IAspectDefinitionCollection Aspects { get; private set; }
    }
}
