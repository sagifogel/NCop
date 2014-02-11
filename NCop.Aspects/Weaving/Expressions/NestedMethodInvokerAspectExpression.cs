using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class NestedMethodInvokerAspectExpression : IAspectExpression
    {
        private readonly IAspectDefinition previousAspectDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal NestedMethodInvokerAspectExpression(IArgumentsWeavingSettings argumentsWeavingSettings, IAspectDefinition previousAspectDefinition) {
            this.previousAspectDefinition = previousAspectDefinition;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var previousAspectArgsType = previousAspectDefinition.ToAspectArgumentImpl();

            return new NestedMethodInvokerAspectWeaver(previousAspectArgsType, aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
