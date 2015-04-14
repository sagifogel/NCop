
namespace NCop.IoC.Fluent
{
    public interface IReusedWithin : IFluentInterface
    {
        IOwnedBy PerThread();
        IOwnedBy PerHttpRequest();
        IOwnedBy WithinHierarchy();
        IOwnedBy WithinContainer();
        IOwnedBy PerHybridRequest();
    }
}
