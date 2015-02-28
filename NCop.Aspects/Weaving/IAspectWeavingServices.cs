
namespace NCop.Aspects.Weaving
{
    public interface IAspectWeavingServices
    {
        IAspectArgsMapper AspectArgsMapper { get; }
        IAspectRepository AspectRepository { get; }
    }
}
