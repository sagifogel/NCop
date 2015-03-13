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
            return new BindingSetPropertyAspectDecoratorWeaver(aspectDefinition.Method, aspectWeavingSettings);
        }
    }
}
