using NCop.Aspects.Weaving.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Advices
{
    public sealed class OnMethodEntryAdviceAttribute : AdviceAttribute
    {
        public override IExpressionReducer Accept(AdviceVisitor visitor) {
            return visitor.Visit(this).Invoke(null);
        }
    }
}
