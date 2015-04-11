
namespace NCop.IoC
{
    public static class IoCExtensions
    {
        public static ILifetimeStrategy ToStrategy(this Lifetime lifetime, INCopDependencyResolver container) {
            return LifetimeStrategyFactory.Get(lifetime, container);
        }
    }
}
