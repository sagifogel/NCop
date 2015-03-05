using NCop.Weaving;

namespace NCop.Aspects.Weaving.Expressions
{
    public interface IAdviceExpression
    {
        IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings);
    }
}
