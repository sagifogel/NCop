using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NCop.Aspects.LifetimeStrategies
{
    public class SingletonLifetimeStrategy : AbstractLifetimeStrategy
    {
        private static IAspect _aspect = null;
        private static bool _initialized = false;
        private static object _syncLock = new object();

        public SingletonLifetimeStrategy(IAspectFactory factory)
            : base(factory) { }
 
        public override IAspect Aspect {
            get {
                return 
                LazyInitializer.EnsureInitialized(ref _aspect, 
                                                  ref _initialized, 
                                                  ref _syncLock, 
                                                  Factory.Create);
            }
        }
    }
}
