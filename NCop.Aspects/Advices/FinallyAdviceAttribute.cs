using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Advices
{
    public sealed class FinallyAdviceAttribute : AdviceAttribute
    {
        public override IExpressionReducer Accept(AdviceVisitor visitor) {
            return visitor.Visit(this).Invoke(null);
        }
    }
}
