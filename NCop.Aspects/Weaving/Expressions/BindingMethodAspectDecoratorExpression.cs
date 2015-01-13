using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingMethodAspectDecoratorExpression : IAspectExpression
    {
        private readonly BindingSettings bindingSettings = null;
        private readonly IMethodAspectDefinition aspectDefinition = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        internal BindingMethodAspectDecoratorExpression(IMethodAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings) {
            this.aspectDefinition = aspectDefinition;
            bindingSettings = aspectDefinition.ToBindingSettings();
            this.argumentsWeavingSettings = argumentsWeavingSettings;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            return new BindingMethodAspectDecoratorWeaver(aspectDefinition, aspectWeavingSettings, argumentsWeavingSettings);
        }
    }
}
