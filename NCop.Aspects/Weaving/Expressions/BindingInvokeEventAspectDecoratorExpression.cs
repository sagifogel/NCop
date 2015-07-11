using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingInvokeEventAspectDecoratorExpression : IAspectExpression
    {
        private readonly IEventAspectDefinition aspectDefinition = null;

        internal BindingInvokeEventAspectDecoratorExpression(IEventAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            return new BindingInvokeEventAspectDecoratorWeaver(aspectDefinition.Member, aspectWeavingSettings);
        }
    }
}
