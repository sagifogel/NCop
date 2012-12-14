using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Runtime;
using System.Reflection;

namespace NCop.Composite.Runtime
{
    public class CompositeRuntimeSettings : AbstractRuntimeSettings
    {
        public CompositeRuntimeSettings(IEnumerable<Assembly> assemblies = null)
            : base(assemblies) {
        }

        public IAspectBuilderProvider AspectBuilderProvider { get; set; }
    }
}
