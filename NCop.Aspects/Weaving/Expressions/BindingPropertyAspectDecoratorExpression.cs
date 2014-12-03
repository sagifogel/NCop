using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingPropertyAspectDecoratorExpression : IAspectMethodExpression
    {
        private readonly BindingSettings bindingSettings = null;
        private readonly IAspectDefinition aspectDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal BindingPropertyAspectDecoratorExpression(IAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings) {
            this.aspectDefinition = aspectDefinition;
            bindingSettings = aspectDefinition.ToBindingSettings();
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectMethodWeavingSettings aspectWeavingSettings) {
            var aspectSettings = aspectWeavingSettings as IAspectPropertyMethodWeavingSettings;

            return new BindingPropertyAspectDecoratorWeaver(aspectDefinition, aspectSettings, argumentsWeavingSettings);
        }
    }
}
