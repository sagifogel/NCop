using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingRemoveEventAspectDecoratorExpression : IAspectExpression
    {
        private readonly IEventAspectDefinition aspectDefinition = null;

        internal BindingRemoveEventAspectDecoratorExpression(IEventAspectDefinition aspectDefinition) {
            this.aspectDefinition = aspectDefinition;
        }

        public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            return new BindingRemoveEventAspectDecoratorWeaver(aspectDefinition.Member, aspectWeavingSettings);
        }
    }
}
