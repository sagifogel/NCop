using System;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Advices
{
    public sealed class OnErrorAdviceAttribute : AdviceAttribute
    {
        public override IAdvice Accept(AdviceVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
