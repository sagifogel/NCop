
namespace NCop.IoC.Fluent
{
    public interface ICastableRegistration<TCastable> : IFluentInterface, IReuseStrategyRegistration
    {
        ICasted ToSelf();
        ICasted From<TService>() where TService : TCastable, new();
    }
}
