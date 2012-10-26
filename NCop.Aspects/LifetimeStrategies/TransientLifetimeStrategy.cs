using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.LifetimeStrategies
{
    public class TransientLifetimeStrategy : AbstractLifetimeStrategy
    {
        public TransientLifetimeStrategy(IAspectFactory factory)
            : base(factory) { }

        public override IAspect Aspect {
            get {
                return Factory.Create();
            }
        }
    }
}
