using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class MethodInvokerAspectExpression : IAspectExpression
    {
        private readonly IAspectDefinition aspectDefinition = null;
        private readonly IAspectDefinition topAspectInScopeDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal MethodInvokerAspectExpression(IAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings, IAspectDefinition topAspectInScopeDefinition) {
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
