using System;

namespace NCop.IoC
{
    internal class HybridRequestLifetimeStrategy : ILifetimeStrategy
    {
        private static readonly ILifetimeStrategy lifetimeStrategyFactory = null;

        static HybridRequestLifetimeStrategy() {
            lifetimeStrategyFactory = HttpRequestLifetimeStrategy.HasContext() ?
                                        new HttpRequestLifetimeStrategy() :
                                        (ILifetimeStrategy)new PerThreadLifetimeStrategy();
        }

        public TService Resolve<TService>(ResolveContext<TService> context) {
            return lifetimeStrategyFactory.Resolve(context);
        }
    }
}
