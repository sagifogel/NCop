using NCop.IoC.Properties;

namespace NCop.IoC
{
    internal static class LifetimeStrategyFactory
    {
        private static readonly IdentityLifetimeStrategy defaultLifetimeStrategy = new IdentityLifetimeStrategy();
        private static readonly HybridRequestLifetimeStrategy hybridRequestLifetimeStrategy = new HybridRequestLifetimeStrategy();

        public static ILifetimeStrategy Get(Lifetime lifetime, INCopDependencyResolver container) {
            switch (lifetime) {
                case Lifetime.None:
                    return defaultLifetimeStrategy;

                case Lifetime.Request:
                    return hybridRequestLifetimeStrategy;

                case Lifetime.Hierarchy:
                    return new HierarchySingletonLifetimeStrategy();

                case Lifetime.Container:
                    return new ContainerSingletonLifetimeStrategy(container);

                default:
                    throw new ResolutionException(Resources.UnknownLifetime);
            }
        }
    }
}
