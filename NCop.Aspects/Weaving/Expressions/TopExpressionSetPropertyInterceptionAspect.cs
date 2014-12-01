using System;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopExpressionSetPropertyInterceptionAspect : AbstractAspectMethodExpression
    {
        internal TopExpressionSetPropertyInterceptionAspect(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectMethodWeavingSettings aspectWeavingSettings) {
            throw new NotImplementedException();
        }
    }
}
