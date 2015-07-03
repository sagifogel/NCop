using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopEventAspectArgumentsWeaver : AbstractTopAspectArgumentsWeaver<EventInfo>
    {
        protected readonly IEventAspectDefinition aspectDefinition = null;

        internal AbstractTopEventAspectArgumentsWeaver(IEventAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition.Member, argumentWeavingSettings, aspectWeavingSettings) {
            this.aspectDefinition = aspectDefinition;
        }
    }
}
