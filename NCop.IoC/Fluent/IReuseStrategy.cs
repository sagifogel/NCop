
namespace NCop.IoC.Fluent
{
    public interface IReuseStrategy : IFluentInterface
    {
        IReusedWithin AsSingleton();
    }
}
