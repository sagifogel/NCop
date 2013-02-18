using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Advices
{
    public sealed class OnMethodInvokeAdviceAttribute : AdviceAttribute
    {
        public override IAdvice Accept(AdviceVisitor visitor) {
           return visitor.Visit(this);
        }
    }
}
