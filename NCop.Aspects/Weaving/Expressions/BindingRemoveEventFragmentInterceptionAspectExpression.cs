using NCop.Aspects.Aspects;
using System;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingRemoveEventFragmentInterceptionAspectExpression : AbstractAspectEventExpression
    {
        public BindingRemoveEventFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IEventAspectDefinition aspectDefinition)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            throw new NotImplementedException();
        }
    }
}
