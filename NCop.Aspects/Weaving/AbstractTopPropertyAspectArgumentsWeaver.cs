using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopPropertyAspectArgumentsWeaver : AbstractTopAspectArgumentsWeaver
    {
        internal AbstractTopPropertyAspectArgumentsWeaver(IArgumentsWeavingSettings argumentWeavingSettings, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
            IsProperty = true;
        }
    }
}
