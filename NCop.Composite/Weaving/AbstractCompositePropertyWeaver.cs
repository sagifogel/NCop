using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal abstract class AbstractCompositePropertyWeaver : AbstractWeaverBuilder, IMethodWeaverBuilder
    {
        protected readonly IPropertyTypeBuilder propertyTypeBuilder = null;
        protected readonly IAspectWeavingServices aspectWeavingServices = null;
        protected readonly ICompositePropertyFragmentMap compositePropertyMap = null;

        protected AbstractCompositePropertyWeaver(IPropertyTypeBuilder propertyTypeBuilder, ICompositePropertyFragmentMap compositePropertyMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositePropertyMap.ContractType, typeDefinition) {
            this.propertyTypeBuilder = propertyTypeBuilder;
            this.compositePropertyMap = compositePropertyMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public abstract IMethodWeaver Build();
    }
}
