using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Core.Extensions;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeInvokeEventWeaverBuilder : AbstractCompositeEventWeaverBuilder
    {
        internal CompositeInvokeEventWeaverBuilder(IEventTypeBuilder eventTypeBuilder, ICompositeEventFragmentMap compositeEventMap, IAspectTypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(eventTypeBuilder, compositeEventMap, typeDefinition, aspectWeavingServices) {
        }

        public override IMethodWeaver Build() {
            var invokeMethod = compositeEventMap.ContractMember.GetInvokeMethod();
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);

            if (compositeEventMap.HasAspectDefinitions) {
                var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                    WeavingSettings = weavingSettings,
                    AspectRepository = aspectWeavingServices.AspectRepository,
                    AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
                };

                return new CompositeInvokeEventWeaver(invokeMethod, typeDefinition, compositeEventMap.AspectDefinitions, aspectWeavingSettings);
            }

            return null;
        }
    }
}
