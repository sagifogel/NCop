using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class MethodInvokerAspectExpression: IAspectExpression
    {
        private readonly IAspectDefinition aspectDefinition = null;
        private readonly IAspectDefinition previousAspectDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal MethodInvokerAspectExpression(IAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings, IAspectDefinition previousAspectDefinition) {
            this.aspectDefinition = aspectDefinition;
            this.previousAspectDefinition = previousAspectDefinition;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var previousAspectArgsType = previousAspectDefinition.ToAspectArgumentImpl();

            return new MethodInvokerAspectWeaver(previousAspectArgsType, aspectDefinition, aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
