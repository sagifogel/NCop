using System;

namespace NCop.IoC
{
    internal class HybridRequestLifetimeStrategy : ILifetimeStrategy
    {
        private static readonly Func<ILifetimeStrategy> lifetimeStrategyFactory = null;

        static HybridRequestLifetimeStrategy() {
            lifetimeStrategyFactory = HttpRequestLifetimeStrategy.HasContext() ?
                                        () => HttpRequestLifetimeStrategy.Instance :
                                        (Func<ILifetimeStrategy>)(() => new PerThreadLifetimeStrategy());
        }

        public TService Resolve<TService>(ResolveContext<TService> context) {
            return lifetimeStrategyFactory().Resolve<TService>(context);
        }
    }
}
