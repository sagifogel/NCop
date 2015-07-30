using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractEventAspectArgumentsWeaver : AbstractTopAspectArgumentsWeaver<EventInfo>
    {
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IEventAspectDefinition aspectDefinition = null;

        internal AbstractEventAspectArgumentsWeaver(IEventAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings, BindingSettings bindingSettings)
            : base(aspectDefinition.Member, argumentWeavingSettings, aspectWeavingSettings) {
            this.bindingSettings = bindingSettings;
            this.aspectDefinition = aspectDefinition;
        }
    }
}
