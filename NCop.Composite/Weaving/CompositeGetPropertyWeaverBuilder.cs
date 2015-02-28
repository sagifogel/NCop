using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeGetPropertyWeaverBuilder : AbstractWeaverBuilder, IMethodWeaverBuilder
    {
        private readonly ICompositePropertyMap compositePropertyMap = null;
        private readonly IAspectWeavingServices aspectWeavingServices = null;

        public CompositeGetPropertyWeaverBuilder(ICompositePropertyMap compositePropertyMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
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

            return new CompositeGetPropertyWeaver(compositePropertyMap.ContractMember, compositePropertyMap.AspectDefinitions, aspectWeavingSettings);
        }
    }
}
