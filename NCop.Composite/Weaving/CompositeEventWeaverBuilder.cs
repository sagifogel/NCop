using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    public class CompositeEventWeaverBuilder : AbstractWeaverBuilder, IEventWeaverBuilder
    {
        private readonly ICompositeEventMap compositeEventMap = null;
        private readonly IAspectWeavingServices aspectWeavingServices = null;

        public CompositeEventWeaverBuilder(ICompositeEventMap compositeEventMap, IAspectTypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositeEventMap.ContractType, typeDefinition) {
            this.compositeEventMap = compositeEventMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public IEventWeaver Build() {
            var addEventFragmentMap = compositeEventMap.AddEventFragmentMap;
            var aspectTypeDefinition = (IAspectTypeDefinition)typeDefinition;
            var removeEventFragmentMap = compositeEventMap.RemoveEventFragmentMap;
            var raiseEventFragmentMap = compositeEventMap.RaiseEventFragmentMap;
            var eventTypeBuilder = new CompositeEventWeaver(typeDefinition, addEventFragmentMap.ContractMember);
            var addEventWeaverBuilder = new CompositeAddEventWeaverBuilder(eventTypeBuilder, addEventFragmentMap, aspectTypeDefinition, aspectWeavingServices);
            var removeEventWeaverBuilder = new CompositeRemoveEventWeaverBuilder(eventTypeBuilder, removeEventFragmentMap, aspectTypeDefinition, aspectWeavingServices);

            eventTypeBuilder.SetAddMethodWeaver(addEventWeaverBuilder.Build());

            if (compositeEventMap.HasAspectDefinitions) {
                var raiseEventWeaverBuilder = new CompositeRaiseEventWeaverBuilder(eventTypeBuilder, raiseEventFragmentMap, aspectTypeDefinition, aspectWeavingServices);

                eventTypeBuilder.SetRaiseMethodWeaver(raiseEventWeaverBuilder.Build());
            }

            eventTypeBuilder.SetRemoveMethodWeaver(removeEventWeaverBuilder.Build());

            return eventTypeBuilder;
        }
    }
}
