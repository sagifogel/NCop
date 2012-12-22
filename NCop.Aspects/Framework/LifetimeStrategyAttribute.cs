using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.LifetimeStrategies;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCop.Aspects.Framework
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class LifetimeStrategyAttribute : Attribute, ILifetimeStrategyProvider
    {
        private bool _initialized = false;
        private object _syncLock = new object();
        private ILifetimeStrategy _strategy = null;
        private KnownLifetimeStrategy _wellKnownLifetimeStrategy;
        private static readonly string _liftimeStrategiesNamespace = "NCop.Aspects.LifetimeStrategies";

        public LifetimeStrategyAttribute(KnownLifetimeStrategy lifetimeStrategy) {
            _wellKnownLifetimeStrategy = lifetimeStrategy;
        }

        private ILifetimeStrategy CreateLifetimeStrategy(Type type) {
            var lifetimeStrategyRepresentation = string.Format("{0}.{1}LifetimeStrategy", _liftimeStrategiesNamespace, _wellKnownLifetimeStrategy);
            var lifetimeStrategyType = Type.GetType(lifetimeStrategyRepresentation);

            return (ILifetimeStrategy)Activator.CreateInstance(lifetimeStrategyType, new object[] { new AspectByReflectionFactory(type) });
        }

        public ILifetimeStrategy GetLifetimeStrategy(Type type) {
            return LazyInitializer.EnsureInitialized(ref _strategy,
                                                     ref _initialized,
                                                     ref _syncLock,
                                                     () => {
                                                         return CreateLifetimeStrategy(type);
                                                     });
        }
    }
}
