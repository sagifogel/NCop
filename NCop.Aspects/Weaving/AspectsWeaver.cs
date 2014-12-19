using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
	internal class AspectsWeaver : IAspectWeaver
	{
		private IAspectWeaver weaver = null;
        private readonly IAspectMethodExpression aspectExpression = null;
        private readonly IAspectMethodWeavingSettings aspectWeavingSettings = null;

        public AspectsWeaver(IAspectMethodExpression aspectExpression, IAspectDefinitionCollection aspectDefinitions, IAspectMethodWeavingSettings aspectWeavingSettings) {
            this.aspectExpression = aspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
		}

		public ILGenerator Weave(ILGenerator ilGenerator) {
            weaver = aspectExpression.Reduce(aspectWeavingSettings);

			return weaver.Weave(ilGenerator);
		}
	}
}
