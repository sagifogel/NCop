using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
	internal abstract class AbstractAspectMethodExpression : IAspectExpression
	{
        protected readonly IAspectExpression aspectExpression = null;
        protected readonly IAspectDefinition aspectDefinition = null;

        internal AbstractAspectMethodExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition = null) {
			this.aspectExpression = aspectExpression;
			this.aspectDefinition = aspectDefinition;
		}

		public abstract IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings);
	}
}