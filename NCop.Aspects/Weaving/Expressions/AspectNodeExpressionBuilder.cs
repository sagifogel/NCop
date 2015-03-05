using System;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class AspectNodeExpressionBuilder : IAspectExpressionBuilder
    {
        private readonly Func<IAspectExpression, IAspectExpression> expressionBuilderFactory = null;

        internal AspectNodeExpressionBuilder(Func<IAspectExpression, IAspectExpression> expressionBuilderFactory) {
            this.expressionBuilderFactory = expressionBuilderFactory;
        }

        public IAspectExpression Build(IAspectExpression aspectExpression = null) {
            return expressionBuilderFactory(aspectExpression);
        }
    }
}
