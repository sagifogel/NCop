using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Advices
{
    public sealed class OnInvokeAdviceAttribute : AdviceAttribute
    {
        public override IAdvice Accept(AdviceVisitor visitor) {
           return visitor.Visit(this);
        }
    }
}
