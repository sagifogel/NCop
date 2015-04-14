
namespace NCop.IoC
{
    internal class TransientLifetimeStrategy : ILifetimeStrategy
    {
        public TService Resolve<TService>(ResolveContext<TService> context) {
            return context.Factory();
        }
    }
}
