using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingSetPropertyAspectDecoratorExpression : IAspectExpression
    {
        private readonly IPropertyAspectDefinition aspectDefinition = null;

        internal BindingSetPropertyAspectDecoratorExpression(IPropertyAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var methodInfo = aspectDefinition.Property.GetSetMethod();
            var aspectSettings = aspectWeavingSettings as IAspectWeavingSettings;

            return new BindingSetPropertyAspectDecoratorWeaver(methodInfo, aspectSettings);
        }
    }
}
