using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    internal class CompositeOnRemoveEventWeaverBuilder : AbstractCompositeEventWeaverBuilder
    {
        internal CompositeOnRemoveEventWeaverBuilder(ICompositeEventMap compositeEventMap, IAspectTypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositeEventMap, typeDefinition, aspectWeavingServices) {
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

                return new CompositeOnRemoveEventWeaver(removeMethod, typeDefinition, compositeEventMap.AspectDefinitions, aspectWeavingSettings);
            }

            return null;// new OnRemoveEventDecoratorWeaver(compositePropertyMap.ContractMember.GetGetMethod(), weavingSettings);
        }
    }
}
