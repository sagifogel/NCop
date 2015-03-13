using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class TopBindingMethodInterceptionAspectExpression : AbstractAspectMethodExpression
    {
        internal TopBindingMethodInterceptionAspectExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition)
            : base(aspectExpression, aspectDefinition) {
        }

		public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var bindingWeaver = new IsolatedMethodInterceptionBindingWeaver(aspectExpression, aspectDefinition, aspectWeavingSettings);

            return new TopBindingMethodInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}
