using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class NestedMethodInvokerAspectExpression : IAspectMethodExpression
    {
        private readonly IAspectDefinition topAspectInScopeDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal NestedMethodInvokerAspectExpression(IArgumentsWeavingSettings argumentsWeavingSettings, IAspectDefinition topAspectInScopeDefinition) {
            this.topAspectInScopeDefinition = topAspectInScopeDefinition;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectMethodWeavingSettings aspectWeavingSettings) {
            var topAspectInScopeArgType = topAspectInScopeDefinition.ToAspectArgumentImpl();

            return new NestedMethodInvokerAspectWeaver(topAspectInScopeArgType, aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
