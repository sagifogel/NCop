using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingRaiseEventAspectDecoratorExpression : IAspectExpression
    {
        private readonly IEventAspectDefinition aspectDefinition = null;

        internal BindingRaiseEventAspectDecoratorExpression(IEventAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            return new BindingRaiseEventAspectDecoratorWeaver(aspectDefinition.Member, aspectWeavingSettings);
        }
    }
}
