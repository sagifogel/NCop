using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Core.Extensions;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    public class CompositePropertyWeaverBuilder : AbstractWeaverBuilder, IPropertyWeaverBuilder
    {
        private readonly ICompositePropertyMap compositePropertyMap = null;
        private readonly IAspectWeavingServices aspectWeavingServices = null;

        public CompositePropertyWeaverBuilder(ICompositePropertyMap compositePropertyMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositePropertyMap.ContractType, typeDefinition) {
            this.compositePropertyMap = compositePropertyMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public IPropertyWeaver Build() {
            var getPropertyMap = compositePropertyMap.GetPropertyFragmentMap;
            var setPropertyMap = compositePropertyMap.SetPropertyFragmentMap;
            var propertyMaps = new[] { getPropertyMap, setPropertyMap };
            var property = propertyMaps.SetIfNotNull(item => item.ContractMember);
            var propertyWeaver = new CompositePropertyWeaver(typeDefinition, property);
            
            if (getPropertyMap.IsNotNull()) {
                var getPropertyWeaverBuilder = new CompositeGetPropertyWeaverBuilder(propertyWeaver, getPropertyMap, typeDefinition, aspectWeavingServices);
                var getPropertyWeaver = getPropertyWeaverBuilder.Build();

                propertyWeaver.SetGetMethodWeaver(getPropertyWeaver);
            }

            if (setPropertyMap.IsNotNull()) {
                var setPropertyWeaverBuilder = new CompositeSetPropertyWeaverBuilder(propertyWeaver, setPropertyMap, typeDefinition, aspectWeavingServices);
                var setPropertyWeaver = setPropertyWeaverBuilder.Build();

                propertyWeaver.SetSetMethodWeaver(setPropertyWeaver);
            }

            return propertyWeaver;
        }
    }
}
