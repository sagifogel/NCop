using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAspectEventExpression : IAspectExpression
    {
        protected readonly IAspectExpression aspectExpression = null;
        protected readonly IEventAspectDefinition aspectDefinition = null;

        internal AbstractAspectEventExpression(IAspectExpression aspectExpression, IEventAspectDefinition aspectDefinition = null) {
            this.aspectExpression = aspectExpression;
            this.aspectDefinition = aspectDefinition;
        }

        public abstract IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings);
    }
}
