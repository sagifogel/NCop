using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Core.Extensions;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeRaiseEventWeaverBuilder : AbstractCompositeEventWeaverBuilder
    {
        internal CompositeRaiseEventWeaverBuilder(IEventTypeBuilder eventTypeBuilder, ICompositeEventFragmentMap compositeEventMap, IAspectTypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
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

                return new CompositeRaiseEventWeaver(eventTypeBuilder, compositeEventMap.ContractMember, invokeMethod, compositeEventMap.AspectDefinitions, aspectWeavingSettings);
            }

            return null;
        }
    }
}
