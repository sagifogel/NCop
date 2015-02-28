using NCop.Aspects.Aspects;

namespace NCop.Composite.Engine
{
    public interface IHasAspectDefinitions
    {
        bool HasAspectDefinitions { get; }
        IAspectDefinitionCollection AspectDefinitions { get; }
    }
}
