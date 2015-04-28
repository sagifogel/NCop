using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeOnAddEventWeaverBuilder : AbstractCompositeEventWeaverBuilder
    {
        internal CompositeOnAddEventWeaverBuilder(ICompositeEventMap compositeEventMap, ITypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositeEventMap, typeDefinition, aspectWeavingServices) {
        }

        public override IMethodWeaver Build() {
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);
            var addMethod = compositeEventMap.ContractMember.AddMethod;

            if (compositeEventMap.HasAspectDefinitions) {
                var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                    WeavingSettings = weavingSettings,
                    AspectRepository = aspectWeavingServices.AspectRepository,
                    AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
                };

                return new CompositeOnAddEventWeaver(addMethod, typeDefinition, compositeEventMap.AspectDefinitions, aspectWeavingSettings);
            }

            return null;// new GetPropertyDecoratorWeaver(compositePropertyMap.ContractMember.GetGetMethod(), weavingSettings);
        }
    }
}
