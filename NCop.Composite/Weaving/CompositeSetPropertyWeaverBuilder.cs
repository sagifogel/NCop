using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeSetPropertyWeaverBuilder : AbstractCompositePropertyWeaver
    {
        public CompositeSetPropertyWeaverBuilder(IPropertyTypeBuilder propertyTypeBuilder, ICompositePropertyFragmentMap compositePropertyMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(propertyTypeBuilder, compositePropertyMap, typeDefinition, aspectWeavingServices) {
        }

        public override IMethodWeaver Build() {
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);
            var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                WeavingSettings = weavingSettings,
                AspectRepository = aspectWeavingServices.AspectRepository,
                AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
            };

            return new CompositeSetPropertyWeaver(propertyTypeBuilder, typeDefinition, compositePropertyMap.ContractMember, compositePropertyMap.AspectDefinitions, aspectWeavingSettings);
        }
    }
}
