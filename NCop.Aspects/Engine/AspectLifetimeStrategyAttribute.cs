using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public abstract class AspectLifetimeStrategyAttribute : Attribute, ILifetimeStrategyProvider
    {
        public abstract LifetimeStrategy LifetimeStrategy { get; }
    }
}
