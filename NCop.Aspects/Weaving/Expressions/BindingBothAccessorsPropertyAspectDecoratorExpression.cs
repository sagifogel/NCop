using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingBothAccessorsPropertyAspectDecoratorExpression : IAspectExpression
    {
        private readonly IPropertyAspectDefinition aspectDefinition = null;

        internal BindingBothAccessorsPropertyAspectDecoratorExpression(IPropertyAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentsWeavingSettings) {
            this.aspectDefinition = aspectDefinition;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var aspectSettings = aspectWeavingSettings as IAspectWeavingSettings;

            return new BindingSetPropertyAspectDecoratorWeaver(null, aspectSettings);
        }
    }
}
