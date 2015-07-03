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
            var invokeEventFragmentMap = compositeEventMap.InvokeEventFragmentMap;
            var eventWeaver = new CompositeEventWeaver(typeDefinition, addEventFragmentMap.ContractMember);
            var addEventWeaverBuilder = new CompositeAddEventWeaverBuilder(eventWeaver, addEventFragmentMap, aspectTypeDefinition, aspectWeavingServices);
            var removeEventWeaverBuilder = new CompositeRemoveEventWeaverBuilder(eventWeaver, removeEventFragmentMap, aspectTypeDefinition, aspectWeavingServices);
            var invokeEventWeaverBuilder = new CompositeInvokeEventWeaverBuilder(eventWeaver, invokeEventFragmentMap, aspectTypeDefinition, aspectWeavingServices);

            eventWeaver.SetAddMethod(addEventWeaverBuilder.Build());
            eventWeaver.SetRemoveMethod(removeEventWeaverBuilder.Build());
            eventWeaver.SetInvokeMethod(invokeEventWeaverBuilder.Build());

            return eventWeaver;
        }
    }
}
