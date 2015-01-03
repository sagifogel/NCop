using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class CompositeMethodWeaver : AspectMethodWeaver
    {
        private readonly AspectMethodWeaver methodWeaver = null;

        internal CompositeMethodWeaver(IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
