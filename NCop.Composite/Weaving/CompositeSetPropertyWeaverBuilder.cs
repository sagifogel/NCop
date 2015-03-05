using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeSetPropertyWeaverBuilder : AbstractWeaverBuilder, IMethodWeaverBuilder
    {
        private readonly ICompositePropertyMap compositePropertyMap = null;
        private readonly IAspectWeavingServices aspectWeavingServices = null;

        public CompositeSetPropertyWeaverBuilder(ICompositePropertyMap compositePropertyMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositePropertyMap.ContractType, typeDefinition) {
            this.compositePropertyMap = compositePropertyMap;
            this.aspectWeavingServices = aspectWeavingServices;
        }

        public IMethodWeaver Build() {
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);
            var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                WeavingSettings = weavingSettings,
                AspectRepository = aspectWeavingServices.AspectRepository,
                AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
            };

            return new CompositeSetPropertyWeaver(compositePropertyMap.ContractMember, compositePropertyMap.AspectDefinitions, aspectWeavingSettings);
        }
    }
}
