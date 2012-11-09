using NCop.Aspects.Engine;
using NCop.Core.Aspects;

namespace NCop.Aspects.Advices
{
    public sealed class OnFinallyAdviceAttribute : AdviceAttribute
    {
        public override IAdvice Accept(AdviceVisitor visitor) {
            return visitor.Visit(this);
        }
    }   
}                   
