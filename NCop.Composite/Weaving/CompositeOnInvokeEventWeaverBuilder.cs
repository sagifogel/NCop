using NCop.Aspects.Weaving;
using NCop.Composite.Engine;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Composite.Weaving
{
    internal class CompositeOnInvokeEventWeaverBuilder : AbstractCompositeEventWeaverBuilder
    {
        internal CompositeOnInvokeEventWeaverBuilder(ICompositeEventMap compositeEventMap, IAspectTypeDefinition typeDefinition, IAspectWeavingServices aspectWeavingServices)
            : base(compositeEventMap, typeDefinition, aspectWeavingServices) {
        }

        public override IMethodWeaver Build() {
            var aspectTypeDefinition = typeDefinition as IAspectTypeDefinition;
            var weavingSettings = new WeavingSettingsImpl(contractType, typeDefinition);

            var aspectWeavingSettings = new AspectWeavingSettingsImpl {
                WeavingSettings = weavingSettings,
                AspectRepository = aspectWeavingServices.AspectRepository,
                AspectArgsMapper = aspectWeavingServices.AspectArgsMapper
            };

            return new CompositeOnInvokeEventWeaver(compositeEventMap.ContractMember, aspectTypeDefinition, compositeEventMap.AspectDefinitions, aspectWeavingSettings);
        }
    }
}
