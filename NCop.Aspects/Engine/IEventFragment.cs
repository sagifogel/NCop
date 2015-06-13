using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Engine
{
    public interface IEventFragment
    {
        IEventExpressionBuilder EventBuilder { get; }
    }
}
