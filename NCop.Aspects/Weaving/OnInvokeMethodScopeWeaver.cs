
using NCop.Aspects.Aspects;
using System.Reflection.Emit;
namespace NCop.Aspects.Weaving
{
    public class OnInvokeMethodScopeWeaver : IAspectWeaver
    {
        private readonly IAspectTypeDefinition typeDefinition = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IAspectDefinitionCollection aspectDefinitions = null;

        public OnInvokeMethodScopeWeaver(IAspectTypeDefinition typeDefinition, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            this.typeDefinition = typeDefinition;
            this.aspectDefinitions = aspectDefinitions;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

        public void Weave(ILGenerator ilGenerator) {

        }
    }
}
