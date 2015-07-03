using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal abstract class AbstractCompositeEventWeaverBuilder : AbstractAspectWeaverBuilder, IMethodWeaverBuilder
    {
        protected readonly IEventTypeBuilder eventTypeBuilder = null;
        protected readonly ICompositeEventFragmentMap compositeEventMap = null;
        protected readonly IAspectWeavingServices aspectWeavingServices = null;

        protected AbstractCompositeEventWeaverBuilder(IEventTypeBuilder eventTypeBuilder, ICompositeEventFragmentMap compositeEventMap, IAspectTypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositeEventMap.ContractType, typeDefinition) {
            this.eventTypeBuilder = eventTypeBuilder;
            this.compositeEventMap = compositeEventMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public abstract IMethodWeaver Build();
    }
}
