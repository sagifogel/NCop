using System;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopExpressionSetPropertyInterceptionAspect : AbstractAspectPropertyExpression
    {
        internal TopExpressionSetPropertyInterceptionAspect(IAspectMethodExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectMethodWeavingSettings aspectWeavingSettings) {
            throw new NotImplementedException();
        }
    }
}
