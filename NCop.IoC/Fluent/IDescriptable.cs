
namespace NCop.IoC.Fluent
{
    public interface IDescriptable : IFluentInterface
    {
        IReuseStrategy Named(string name);
    }
}
