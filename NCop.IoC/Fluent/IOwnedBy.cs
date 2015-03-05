
namespace NCop.IoC.Fluent
{
    public interface IOwnedBy : IFluentInterface
    {
        void OwnedExternally();
        void OwnedByContainer();
    }
}
