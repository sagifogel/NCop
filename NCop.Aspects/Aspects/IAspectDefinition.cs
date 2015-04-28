
namespace NCop.Aspects.Aspects
{
    public interface IAspectDefinition<TMember> : IAspectDefinition
    {
        TMember Member { get; }
    }
}
