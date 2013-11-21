using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Advices
{
    public sealed class OnMethodSuccessAdviceAttribute : AdviceAttribute
    {
        public override IExpressionReducer Accept(AdviceVisitor visitor) {
            return visitor.Visit(this).Invoke(null);
        }
    }
}
