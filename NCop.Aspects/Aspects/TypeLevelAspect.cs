using NCop.Aspects.Framework;
using NCop.Aspects.LifetimeStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    [LifetimeStrategy(KnownLifetimeStrategy.Singleton)]
    public abstract class TypeLevelAspectAttribute : AspectAttribute
    {
    }
}
