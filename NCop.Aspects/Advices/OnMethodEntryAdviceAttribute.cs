using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Advices
{
    public sealed class OnMethodEntryAdviceAttribute : AdviceAttribute
    {
        public override IAdvice Accept(AdviceVisitor visitor) {
            return visitor.Visit(this);
        }
    }
}
