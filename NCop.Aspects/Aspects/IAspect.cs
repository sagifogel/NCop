using NCop.Aspects.Engine;
using System;

namespace NCop.Aspects.Aspects
{
    public interface IAspect
    {
        Type AspectType { get; }
        int AspectPriority { get; }
        LifetimeStrategy LifetimeStrategy { get; }
    }
}
