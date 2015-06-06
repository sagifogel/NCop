using System;
using NCop.Weaving;
using NCop.Aspects.Weaving;
using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    public class OnInvokeMethodWeaverBuilder : IMethodWeaverBuilder
    {
        private readonly EventInfo @event = null;
        private readonly IAspectTypeDefinition typeDefinition = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IAspectDefinitionCollection aspectDefinitions = null;

        public OnInvokeMethodWeaverBuilder(EventInfo @event, IAspectTypeDefinition typeDefinition, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings) {
            this.@event = @event;
            this.typeDefinition = typeDefinition;
            this.aspectDefinitions = aspectDefinitions;
            this.aspectWeavingSettings = aspectWeavingSettings;
        }

        public IMethodWeaver Build() {
            return new OnInvokeMethodWeaver(@event, typeDefinition, aspectDefinitions, aspectWeavingSettings);
        }
    }
}
