using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Aspects
{
    public interface IAspectDefinition
    {
        IAspect Aspect { get; }
		AspectType AspectType { get; }
        IAdviceDefinitionCollection Advices { get; }
    }
}
