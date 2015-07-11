using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingAddEventAspectDecoratorExpression : IAspectExpression
    {
        private readonly IEventAspectDefinition aspectDefinition = null;

        internal BindingAddEventAspectDecoratorExpression(IEventAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            return new BindingAddEventAspectDecoratorWeaver(aspectDefinition.Member, aspectWeavingSettings);
        }
    }
}
