using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal class ActionAspectArgsMappingWeaver : AbstractAspectArgsMappingWeaver
    {
        internal ActionAspectArgsMappingWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
        }
    }
}
