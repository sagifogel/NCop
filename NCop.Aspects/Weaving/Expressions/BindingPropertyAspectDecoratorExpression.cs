using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingPropertyAspectDecoratorExpression : IAspectMethodExpression
    {
        private readonly IAspectDefinition aspectDefinition = null;

        internal BindingPropertyAspectDecoratorExpression(IAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var aspectSettings = aspectWeavingSettings as IAspectPropertyMethodWeavingSettings;

            return new BindingPropertyAspectDecoratorWeaver(aspectDefinition.Member, aspectSettings);
        }
    }
}
