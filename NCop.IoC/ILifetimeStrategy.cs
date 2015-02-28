
namespace NCop.IoC
{
    internal interface ILifetimeStrategy
    {
        TService Resolve<TService>(ResolveContext<TService> context) ;
    }
}
