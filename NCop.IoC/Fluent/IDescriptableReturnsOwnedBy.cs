
namespace NCop.IoC.Fluent
{
	public interface IDescriptableReturnsOwnedBy : IFluentInterface
    {
        IOwnedBy Named(string name);
    }
}
