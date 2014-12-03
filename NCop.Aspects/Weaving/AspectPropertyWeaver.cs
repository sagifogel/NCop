using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class AspectPropertyWeaver : AspectMethodWeaver
    {
        public AspectPropertyWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectPropertyMethodWeavingSettings aspectWeavingSettings)
            : base(aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
