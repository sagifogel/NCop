using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingAspectDecoratorExpression : IAspectExpression
    {
        private readonly BindingSettings bindingSettings = null;
        private readonly IAspectDefinition aspectDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal BindingAspectDecoratorExpression(IAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings) {
            this.aspectDefinition = aspectDefinition;
            bindingSettings = aspectDefinition.ToBindingSettings();
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            return new BindingAspectDecoratorWeaver(aspectDefinition, aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
