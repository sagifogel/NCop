
namespace NCop.IoC
{
    public static class IoCExtensions
    {
        internal static ILifetimeStrategy ToStrategy(this ReuseScope scope, INCopDependencyResolver container) {
            return LifetimeStrategyFactory.Get(scope, container);
        }
    }
}
