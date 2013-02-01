using System;
using NCop.Aspects.Engine;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Advices
{
    public sealed class OnExceptionAdviceAttribute : AdviceAttribute
    {
        public override IAdvice Accept(AdviceVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
