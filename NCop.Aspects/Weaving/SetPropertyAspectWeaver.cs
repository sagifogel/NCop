using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving
{
    public class SetPropertyAspectWeaver : AspectPropertyWeaver
    {
        public SetPropertyAspectWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectPropertyMethodWeavingSettings aspectWeavingSettings)
            : base(aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
