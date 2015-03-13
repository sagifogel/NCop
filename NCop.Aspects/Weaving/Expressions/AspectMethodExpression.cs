using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class AspectMethodExpression : IAspectExpression
	{
		private readonly IAspectExpression aspectExpression = null;

		internal AspectMethodExpression(IAspectExpression aspectExpression) {
			this.aspectExpression = aspectExpression;
		}

		public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
			return new AspectsWeaver(aspectExpression, aspectWeavingSettings);
		}
	}
}
