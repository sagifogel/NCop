using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingGetPropertyAspectDecoratorExpression : IAspectExpression
    {
        private readonly IPropertyAspectDefinition aspectDefinition = null;

        internal BindingGetPropertyAspectDecoratorExpression(IPropertyAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var methodInfo = aspectDefinition.Property.GetGetMethod();

            return new BindingGetPropertyAspectDecoratorWeaver(methodInfo, aspectWeavingSettings);
        }
    }
}
