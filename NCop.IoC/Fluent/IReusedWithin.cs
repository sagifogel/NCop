
namespace NCop.IoC.Fluent
{
    public interface IReusedWithin : IFluentInterface
    {
        IOwnedBy ReusedWithinHierarchy();
        IOwnedBy ReusedWithinContainer();
    }
}
