
namespace NCop.IoC
{
	public interface ICanCreateChildContainer
	{
        INCopDependencyContainer CreateChildContainer();
	}
}
