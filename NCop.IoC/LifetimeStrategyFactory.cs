using NCop.IoC.Properties;

namespace NCop.IoC
{
    internal static class LifetimeStrategyFactory
    {
        private static readonly TransientLifetimeStrategy defaultLifetimeStrategy = new TransientLifetimeStrategy();
        private static readonly HybridRequestLifetimeStrategy hybridRequestLifetimeStrategy = new HybridRequestLifetimeStrategy();

        public static ILifetimeStrategy Get(Lifetime lifetime, INCopDependencyResolver container) {
            switch (lifetime) {
                case Lifetime.None:
                    return defaultLifetimeStrategy;

                case Lifetime.PerThread :
                    return PerThreadLifetimeStrategy.Instance;

                case Lifetime.HttpRequest:
                    return HttpRequestLifetimeStrategy.Instance;

                case Lifetime.Hierarchy:
                    return new HierarchySingletonLifetimeStrategy();

                case Lifetime.Container:
                    return new ContainerSingletonLifetimeStrategy(container);

                case Lifetime.HybridRequest:
                    return hybridRequestLifetimeStrategy;

                default:
                    throw new ResolutionException(Resources.UnknownLifetime);
            }
        }
    }
}
