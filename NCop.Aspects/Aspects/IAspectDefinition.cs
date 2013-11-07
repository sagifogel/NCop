using NCop.Aspects.Advices;

namespace NCop.Aspects.Aspects
{
    public interface IAspectDefinition
    {
        IAspect Aspect { get; }
        IAdviceDefinitionCollection Advices { get; }
    }
}
