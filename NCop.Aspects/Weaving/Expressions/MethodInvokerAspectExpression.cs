using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class MethodInvokerAspectExpression : IAspectExpression
    {
        private readonly IMethodAspectDefinition aspectDefinition = null;
        private readonly IMethodAspectDefinition topAspectInScopeDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal MethodInvokerAspectExpression(IMethodAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings, IMethodAspectDefinition topAspectInScopeDefinition) {
            this.aspectDefinition = aspectDefinition;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
            this.topAspectInScopeDefinition = topAspectInScopeDefinition;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var topAspectInScopeArgType = topAspectInScopeDefinition.ToAspectArgumentImpl();

            return new MethodInvokerAspectWeaver(topAspectInScopeArgType, aspectDefinition, aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
