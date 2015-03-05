using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AspectsWeaver : IAspectWeaver
    {
        private readonly IAspectExpression aspectExpression = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;

        public AspectsWeaver(IAspectExpression aspectExpression, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            this.aspectExpression = aspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

        public void Weave(ILGenerator ilGenerator) {
            var weaver = aspectExpression.Reduce(aspectWeavingSettings);

            weaver.Weave(ilGenerator);
        }
    }
}
