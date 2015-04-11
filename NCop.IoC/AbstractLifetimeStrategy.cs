
namespace NCop.IoC
{
    internal abstract class AbstractLifetimeStrategy : ILifetimeStrategy
    {
        public abstract TService Resolve<TService>(ResolveContext<TService> context);
    }
}
