
namespace NCop.Aspects.Aspects
{
    public interface IAspectDefinition<out TMember> : IAspectDefinition
    {
        TMember Member { get; }
    }
}
