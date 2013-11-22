using NCop.Aspects.Aspects;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectNodeExpressionBuilder : IAspectExpressionBuilder
    {
        private readonly Func<IAspectExpression, IAspectExpression> expressionBuilderFactory = null;

        public AspectNodeExpressionBuilder(Func<IAspectExpression, IAspectExpression> expressionBuilderFactory) {
            this.expressionBuilderFactory = expressionBuilderFactory;
        }

        public IAspectExpression Build(IAspectExpression expression = null) {
            return expressionBuilderFactory(expression);
        }
    }
}
