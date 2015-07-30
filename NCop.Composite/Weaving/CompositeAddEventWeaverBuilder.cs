using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeAddEventWeaverBuilder : AbstractCompositeEventWeaverBuilder
    {
        internal CompositeAddEventWeaverBuilder(IEventTypeBuilder eventTypeBuilder, ICompositeEventFragmentMap compositeEventMap, IAspectTypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(eventTypeBuilder, compositeEventMap, typeDefinition, aspectWeavingServices) {
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

                return new CompositeAddEventWeaver(eventTypeBuilder, addMethod, compositeEventMap.AspectDefinitions, aspectWeavingSettings);
            }

            return null;// new GetPropertyDecoratorWeaver(compositePropertyMap.ContractMember.GetGetMethod(), weavingSettings);
        }
    }
}
