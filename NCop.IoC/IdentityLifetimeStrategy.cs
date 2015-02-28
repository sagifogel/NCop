
namespace NCop.IoC
{
	internal class IdentityLifetimeStrategy : ILifetimeStrategy
    {
        public TService Resolve<TService>(ResolveContext<TService> context) {
            return context.Factory();
        }
    }
}
