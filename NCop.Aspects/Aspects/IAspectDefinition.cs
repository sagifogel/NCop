using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Aspects
{
    public interface IAspectDefinition : IAcceptsVisitor<IHasAspectExpression, AspectVisitor>
    {
        IAspect Aspect { get; }
        AspectType AspectType { get; }
        IAdviceDefinitionCollection Advices { get; }
    }
}
