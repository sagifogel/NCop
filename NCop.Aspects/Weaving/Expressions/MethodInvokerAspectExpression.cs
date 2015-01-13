using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class MethodInvokerAspectExpression : IAspectExpression
    {
        private readonly IMethodAspectDefinition aspectDefinition = null;
        private readonly IMethodAspectDefinition topAspectInScopeDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal MethodInvokerAspectExpression(IMethodAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings, IMethodAspectDefinition topAspectInScopeDefinition) {
            this.aspectDefinition = aspectDefinition;
            this.topAspectInScopeDefinition = topAspectInScopeDefinition;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var topAspectInScopeArgType = topAspectInScopeDefinition.ToAspectArgumentImpl();

            return new MethodInvokerAspectWeaver(topAspectInScopeArgType, aspectDefinition, aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
