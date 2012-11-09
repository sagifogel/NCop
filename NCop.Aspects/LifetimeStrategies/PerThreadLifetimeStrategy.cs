using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NCop.Core.Aspects;

namespace NCop.Aspects.LifetimeStrategies
{
    public class PerThreadLifetimeStrategy : AbstractLifetimeStrategy
    {
        private ThreadLocal<IAspect> _aspectThread = null;

        public PerThreadLifetimeStrategy(IAspectFactory factory)
            : base(factory) {
            //_aspectThread = new ThreadLocal<IAspect>(Factory.Create, true);
        }

         public override IAspect Aspect {
            get {
                return _aspectThread.Value;
            }
        }
    }
}
