using NCop.Aspects.Aspects;

namespace NCop.Aspects.Engine
{
    public interface IHasAspectDefinitions
    {
        bool HasAspectDefinitions { get; }
        IAspectDefinitionCollection AspectDefinitions { get; }
    }
}
