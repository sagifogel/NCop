using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
	internal class AspectMethodExpression : IAspectExpression
	{
		private readonly IAspectExpression aspectExpression = null;
		private readonly IAspectDefinitionCollection aspectsDefinitions = null;

		internal AspectMethodExpression(IAspectExpression aspectExpression, IAspectDefinitionCollection aspectsDefinitions) {
			this.aspectExpression = aspectExpression;
			this.aspectsDefinitions = aspectsDefinitions;
		}

		public IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
			return new AspectsWeaver(aspectExpression, aspectsDefinitions, aspectWeavingSettings);
		}
	}
}
