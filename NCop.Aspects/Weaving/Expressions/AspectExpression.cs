using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectExpression : AbstractAspectExpression
    {
        internal AspectExpression(IAspectExpression expression)
            : base(expression) {
        }

        public override IMethodScopeWeaver Reduce() {
            return expression.Reduce();
        }
    }
}
