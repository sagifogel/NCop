using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class NestedMethodInvokerAspectExpression : IAspectExpression
    {
        private readonly IMethodAspectDefinition topAspectInScopeDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal NestedMethodInvokerAspectExpression(IArgumentsWeavingSettings argumentsWeavingSettings, IMethodAspectDefinition topAspectInScopeDefinition) {
            this.topAspectInScopeDefinition = topAspectInScopeDefinition;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var topAspectInScopeArgType = topAspectInScopeDefinition.ToAspectArgumentImpl();

            return new NestedMethodInvokerAspectWeaver(topAspectInScopeDefinition.Method, topAspectInScopeArgType, aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
