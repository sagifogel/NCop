using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal abstract class AbstractCompositeEventWeaverBuilder : AbstractWeaverBuilder, IMethodWeaverBuilder
    {
        protected readonly ICompositeEventMap compositeEventMap = null;
        protected readonly IAspectWeavingServices aspectWeavingServices = null;

        protected AbstractCompositeEventWeaverBuilder(ICompositeEventMap compositeEventMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositeEventMap.ContractType, typeDefinition) {
            this.compositeEventMap = compositeEventMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public abstract IMethodWeaver Build();
    }
}
