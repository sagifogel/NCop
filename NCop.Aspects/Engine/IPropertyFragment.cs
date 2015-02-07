using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Engine
{
    public interface IPropertyFragment
    {
        IPropertyExpressionBuilder PropertyBuilder { get; }
    }
}
