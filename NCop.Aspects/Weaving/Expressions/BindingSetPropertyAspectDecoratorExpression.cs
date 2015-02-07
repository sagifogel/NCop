using NCop.Aspects.Aspects;

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

            return new BindingSetPropertyAspectDecoratorWeaver(methodInfo, aspectWeavingSettings);
        }
    }
}
