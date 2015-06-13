using NCop.Aspects.Aspects;
using System;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingAddEventFragmentInterceptionAspectExpression : AbstractAspectEventExpression
    {
        public BindingAddEventFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IEventAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder eventBuilder)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            throw new NotImplementedException();
        }
    }
}
