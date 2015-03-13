using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class NestedOnMethodBoundaryAspectExpression : AbstractAspectMethodExpression
    {
        internal NestedOnMethodBoundaryAspectExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition)
            : base(aspectExpression, aspectDefinition) {
        }

		public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var nestedWeaver = aspectExpression.Reduce(aspectWeavingSettings);

            return new NestedOnMethodBoundaryAspectWeaver(nestedWeaver, aspectDefinition, aspectWeavingSettings);
        }
    }
}
