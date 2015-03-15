
namespace NCop.IoC.Fluent
{
    public interface ICastableRegistration<in TCastable> : IReuseStrategyRegistration
    {
        ICasted ToSelf();
        ICasted From<TService>() where TService : TCastable, new();
    }
}
