using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Engine;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.LifetimeStrategies
{
    public abstract class AbstractLifetimeStrategy : ILifetimeStrategy
    {
        public AbstractLifetimeStrategy(IAspectFactory factory) {
            Factory = factory;
        }

        public IAspectFactory Factory { get; private set; }

        public abstract IAspect Aspect { get; }
    }
}
