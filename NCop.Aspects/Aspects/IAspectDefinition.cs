using NCop.Aspects.Advices;

namespace NCop.Aspects.Aspects
{
    public interface IAspectDefinition
    {
        IAspect Aspect { get; }
        int AspectPriority { get; }
        IAdviceCollection Advices { get; }
    }
}
