using NCop.Aspects.Aspects;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public class AspectEventWeaver : AbstractAspectMethodWeaver
    {
        protected readonly IEventTypeBuilder eventTypeBuilder = null;

        public AspectEventWeaver(IEventTypeBuilder eventTypeBuilder, MethodInfo method, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
            this.eventTypeBuilder = eventTypeBuilder;
        }
    }
}
