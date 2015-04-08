
namespace NCop.IoC
{
    public interface ILifetimeStrategy
    {
        TService Resolve<TService>(ResolveContext<TService> context);
    }
}
