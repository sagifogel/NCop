using NCop.Aspects.Aspects;

namespace NCop.Aspects.Engine
{
    public interface IAspectContainer : IHasAspectDefinitions
    {
        IAspectDefinitionCollection AspectDefinitions { get; }
    }
}
