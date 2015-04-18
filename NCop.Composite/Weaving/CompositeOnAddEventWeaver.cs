using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Composite.Weaving
{
    internal class CompositeOnAddEventWeaver : AspectEventWeaver
    {
        internal CompositeOnAddEventWeaver(MethodInfo method, ITypeDefinition typeDefinition, IAspectDefinitionCollection aspectDefinitions, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectDefinitions, aspectWeavingSettings) {
        }
    }
}
