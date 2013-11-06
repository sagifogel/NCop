using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public class PerThreadAspectAttribute : AspectLifetimeStrategyAttribute
    {
        public override LifetimeStrategy LifetimeStrategy {
            get {
                return LifetimeStrategy.PerThread;
            }
        }
    }
}
