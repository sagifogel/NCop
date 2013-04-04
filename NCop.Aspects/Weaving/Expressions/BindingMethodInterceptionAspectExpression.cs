using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingMethodInterceptionAspectExpression : AbstractAspectExpression
    {
        private readonly IAspectDefinition topAspectInScopeDefinition = null;

        internal BindingMethodInterceptionAspectExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectDefinition topAspectInScopeDefinition)
            : base(aspectExpression, aspectDefinition) {
            this.topAspectInScopeDefinition = topAspectInScopeDefinition;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var topAspectInScopeArgType = topAspectInScopeDefinition.ToAspectArgumentImpl();
            var bindingWeaver = new IsolatedMethodInterceptionBindingWeaver(aspectExpression, aspectDefinition, aspectWeavingSettings);

            return new BindingMethodInterceptionAspectWeaver(topAspectInScopeArgType, aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}
