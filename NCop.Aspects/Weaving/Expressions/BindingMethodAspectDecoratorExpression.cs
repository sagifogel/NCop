using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingMethodAspectDecoratorExpression : IAspectExpression
    {
        private readonly BindingSettings bindingSettings = null;
        private readonly IAspectDefinition aspectDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal BindingMethodAspectDecoratorExpression(IAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings) {
            this.aspectDefinition = aspectDefinition;
            bindingSettings = aspectDefinition.ToBindingSettings();
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            return new BindingMethodAspectDecoratorWeaver(aspectDefinition, aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
