
namespace NCop.IoC
{
    internal class HybridRequestLifetimeStrategy : ILifetimeStrategy
    {
        private static readonly ILifetimeStrategy lifetimeStrategyFactory = null;

        static HybridRequestLifetimeStrategy() {
            lifetimeStrategyFactory = HttpRequestLifetimeStrategy.HasContext() ?
                                        HttpRequestLifetimeStrategy.Instance :
                                        (ILifetimeStrategy)PerThreadLifetimeStrategy.Instance;
        }

        public TService Resolve<TService>(ResolveContext<TService> context) {
            return lifetimeStrategyFactory.Resolve(context);
        }
    }
}
