using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
	internal abstract class AbstractAspectMethodExpression : IAspectMethodExpression
	{
		protected readonly IAspectMethodExpression aspectExpression = null;
		protected readonly IAspectDefinition aspectDefinition = null;

		internal AbstractAspectMethodExpression(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition = null) {
			this.aspectExpression = aspectExpression;
			this.aspectDefinition = aspectDefinition;
		}

		public abstract IAspectWeaver Reduce(IAspectMethodWeavingSettings aspectWeavingSettings);
	}
}