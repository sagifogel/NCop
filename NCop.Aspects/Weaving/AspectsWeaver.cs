using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
	internal class AspectsWeaver : IAspectWeaver
	{
		private IAspectWeaver weaver = null;
        private readonly IAspectMethodExpression aspectExpression = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;

        public AspectsWeaver(IAspectMethodExpression aspectExpression, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            this.aspectExpression = aspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
		}

		public void Weave(ILGenerator ilGenerator) {
            aspectExpression.Reduce(aspectWeavingSettings)
                            .Weave(ilGenerator);
		}
	}
}
