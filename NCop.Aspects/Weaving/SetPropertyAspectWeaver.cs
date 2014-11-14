using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving
{
    public class SetPropertyAspectWeaver : AspectMethodWeaver
    {
        public SetPropertyAspectWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
