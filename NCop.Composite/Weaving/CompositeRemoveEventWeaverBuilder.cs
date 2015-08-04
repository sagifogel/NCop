using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeRemoveEventWeaverBuilder : AbstractCompositeEventWeaverBuilder
    {
        internal CompositeRemoveEventWeaverBuilder(IEventTypeBuilder eventTypeBuilder, ICompositeEventFragmentMap compositeEventMap, IAspectTypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(eventTypeBuilder, compositeEventMap, typeDefinition, aspectWeavingServices) {
        }

        public override IMethodWeaver Build() {
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);
            var removeMethod = compositeEventMap.ContractMember.RemoveMethod;

            if (compositeEventMap.HasAspectDefinitions) {
                var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                    WeavingSettings = weavingSettings,
                    AspectRepository = aspectWeavingServices.AspectRepository,
                    AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
                };

                return new CompositeRemoveEventWeaver(eventTypeBuilder, removeMethod, compositeEventMap.AspectDefinitions, aspectWeavingSettings);
            }

            return new RemoveEventDecoratorWeaver(eventTypeBuilder, compositeEventMap.ContractMember, weavingSettings);
        }
    }
}
