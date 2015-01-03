using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class NestedMethodInterceptionAspectExpression : AbstractAspectMethodExpression
    {
        private readonly IAspectDefinition topAspectInScopeDefinition = null;

        internal NestedMethodInterceptionAspectExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectDefinition topAspectInScopeDefinition)
            : base(aspectExpression, aspectDefinition) {
            this.topAspectInScopeDefinition = topAspectInScopeDefinition;
        }

		public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var topAspectInScopeArgType = topAspectInScopeDefinition.ToAspectArgumentImpl();
            var bindingWeaver = new IsolatedMethodInterceptionBindingWeaver(aspectExpression, aspectDefinition, aspectWeavingSettings);

            return new NestedMethodInterceptionAspectWeaver(topAspectInScopeArgType, aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}