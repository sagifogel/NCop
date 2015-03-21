using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeGetPropertyWeaverBuilder : AbstractCompositePropertyWeaver
    {
        public CompositeGetPropertyWeaverBuilder(IPropertyTypeBuilder propertyTypeBuilder, ICompositePropertyFragmentMap compositePropertyMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(propertyTypeBuilder, compositePropertyMap, typeDefinition, aspectWeavingServices) {
        }

        public override IMethodWeaver Build() {
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);

            if (compositePropertyMap.HasAspectDefinitions) {
                var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                    WeavingSettings = weavingSettings,
                    AspectRepository = aspectWeavingServices.AspectRepository,
                    AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
                };

                return new CompositeGetPropertyWeaver(propertyTypeBuilder, typeDefinition, compositePropertyMap.ContractMember, compositePropertyMap.AspectDefinitions, aspectWeavingSettings);
            }

            return new GetPropertyDecoratorWeaver(compositePropertyMap.ContractMember.GetGetMethod(), weavingSettings);
        }
    }
}
