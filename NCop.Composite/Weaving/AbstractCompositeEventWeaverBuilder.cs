using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal abstract class AbstractCompositeEventWeaverBuilder : AbstractAspectWeaverBuilder, IMethodWeaverBuilder
    {
        protected readonly ICompositeEventMap compositeEventMap = null;
        protected readonly IAspectWeavingServices aspectWeavingServices = null;

        protected AbstractCompositeEventWeaverBuilder(ICompositeEventMap compositeEventMap, IAspectTypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositeEventMap.ContractType, typeDefinition) {
            this.compositeEventMap = compositeEventMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public abstract IMethodWeaver Build();
    }
}
