using NCop.Aspects.Aspects;
using System;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopEventInterceptionAspectExpression : AbstractAspectEventExpression
    {
        public TopEventInterceptionAspectExpression(IAspectExpression aspectExpression, IEventAspectDefinition aspectDefinition)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            throw new NotImplementedException();
        }
    }
}
