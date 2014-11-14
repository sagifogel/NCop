using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    public class GetPropertyAspectWeaver : AspectMethodWeaver
    {
        public GetPropertyAspectWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
