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
        private readonly Func<IAspectMethodExpression, IAspectMethodExpression> expressionBuilderFactory = null;

        internal AspectNodeExpressionBuilder(Func<IAspectMethodExpression, IAspectMethodExpression> expressionBuilderFactory) {
            this.expressionBuilderFactory = expressionBuilderFactory;
        }

        public IAspectMethodExpression Build(IAspectMethodExpression aspectExpression = null) {
            return expressionBuilderFactory(aspectExpression);
        }
    }
}
