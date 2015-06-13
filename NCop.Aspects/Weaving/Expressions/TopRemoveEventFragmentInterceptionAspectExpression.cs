using NCop.Aspects.Aspects;
using System;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopRemoveEventFragmentInterceptionAspectExpression : AbstractAspectEventExpression
    {
        public TopRemoveEventFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IEventAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder eventBuilder)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            return null;
        }
    }
}
