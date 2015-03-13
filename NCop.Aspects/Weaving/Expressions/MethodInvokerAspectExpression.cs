using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class MethodInvokerAspectExpression : IAspectExpression
    {
        private readonly IAspectDefinition aspectDefinition = null;
        private readonly IAspectDefinition topAspectInScopeDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal MethodInvokerAspectExpression(IAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings, IAspectDefinition topAspectInScopeDefinition) {
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
