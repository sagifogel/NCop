using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving
{
    public class GetPropertyAspectWeaver : AspectPropertyWeaver
    {
        public GetPropertyAspectWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectPropertyMethodWeavingSettings aspectWeavingSettings)
            : base(aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
