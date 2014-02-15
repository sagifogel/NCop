using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal class TopGetReturnValueWeaver : AbstractGetReturnValueWeaver
    {
        internal TopGetReturnValueWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSetings)
            : base(aspectWeavingSettings, argumentsWeavingSetings) {
        }

        protected override Type GetAspectType() {
            return argumentsWeavingSetings.ArgumentType;
        }
    }
}
