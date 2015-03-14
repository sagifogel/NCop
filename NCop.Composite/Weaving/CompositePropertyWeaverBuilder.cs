using System.Reflection;
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
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);
            var propertyWeaver = new CompositePropertyWeaver(typeDefinition, property);
            var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                WeavingSettings = weavingSettings,
                AspectRepository = aspectWeavingServices.AspectRepository,
                AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
            };

            if (getPropertyMap.IsNotNull()) {
                var getPropertyWeaver = new CompositeGetPropertyWeaver(propertyWeaver, typeDefinition, property, getPropertyMap.AspectDefinitions, aspectWeavingSettings);

                propertyWeaver.SetGetMethodWeaver(getPropertyWeaver);
            }

            if (setPropertyMap.IsNotNull()) {
                var setPropertyWeaver = new CompositeSetPropertyWeaver(propertyWeaver, typeDefinition, property, setPropertyMap.AspectDefinitions, aspectWeavingSettings);

                propertyWeaver.SetSetMethodWeaver(setPropertyWeaver);
            }

            return propertyWeaver;
        }
    }
}
