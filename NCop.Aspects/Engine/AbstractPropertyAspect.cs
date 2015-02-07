using NCop.Aspects.Aspects;
using System;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractPropertyAspect : IAspect
    {
        public Type AspectType { get; internal set; }
        public int AspectPriority { get; internal set; }
        public LifetimeStrategy LifetimeStrategy { get; internal set; }
    }
}
