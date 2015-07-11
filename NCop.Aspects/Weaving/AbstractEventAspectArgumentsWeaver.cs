using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractEventAspectArgumentsWeaver : AbstractTopAspectArgumentsWeaver<EventInfo>
    {
        protected readonly IEventAspectDefinition aspectDefinition = null;

        internal AbstractEventAspectArgumentsWeaver(IEventAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition.Member, argumentWeavingSettings, aspectWeavingSettings) {
            this.aspectDefinition = aspectDefinition;
        }
    }
}
