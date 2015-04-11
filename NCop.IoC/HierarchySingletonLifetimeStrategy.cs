
namespace NCop.IoC
{
    internal class HierarchySingletonLifetimeStrategy : AbstractSingletonLifetimeStrategy
    {
        public override TService Resolve<TService>(ResolveContext<TService> context) {
            return lazy.Get(context.Factory);
        }
    }
}
