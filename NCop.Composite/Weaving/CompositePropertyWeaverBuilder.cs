using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;
using System.Reflection;

namespace NCop.Composite.Weaving
{
    internal class CompositePropertyWeaverBuilder : AbstractWeaverBuilder<PropertyInfo>, IPropertyWeaverBuilder
    {
        private readonly ICompositePropertyMap compositePropertyMap = null;
        private readonly IAspectWeavingServices aspectWeavingServices = null;

        public CompositePropertyWeaverBuilder(ICompositePropertyMap compositePropertyMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositePropertyMap.ContractType, typeDefinition) {
            this.compositePropertyMap = compositePropertyMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public IPropertyWeaver Build() {
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);

            if (compositePropertyMap.HasAspectDefinitions) {
                var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                    WeavingSettings = weavingSettings,
                    AspectRepository = aspectWeavingServices.AspectRepository,
                    AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
                };

                return new CompositePropertyWeaver(compositePropertyMap.ContractMember, compositePropertyMap.AspectDefinitions, aspectWeavingSettings);
            }

            return new PropertyDecoratorWeaver(compositePropertyMap.ContractMember, weavingSettings);
        }
    }
}
