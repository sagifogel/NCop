using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Core.Extensions;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    public class CompositeEventWeaverBuilder : AbstractWeaverBuilder, IEventWeaverBuilder
    {
        private readonly ICompositeEventMap compositeEventMap = null;
        private readonly IAspectWeavingServices aspectWeavingServices = null;

        public CompositeEventWeaverBuilder(ICompositeEventMap compositeEventMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositeEventMap.ContractType, typeDefinition) {
            this.compositeEventMap = compositeEventMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public IEventWeaver Build() {
            var eventWeaver = new CompositeEventWeaver(typeDefinition, compositeEventMap.ContractMember);
            var addEventWeaver = new CompositeOnAddEventWeaverBuilder(compositeEventMap, typeDefinition, aspectWeavingServices);
            var removeEventWeaver = new CompositeOnRemoveEventWeaverBuilder(compositeEventMap, typeDefinition, aspectWeavingServices);

            eventWeaver.SetAddOnMethod(addEventWeaver.Build());
            eventWeaver.SetRemoveOnMethod(removeEventWeaver.Build());

            return eventWeaver;
        }
    }
}
