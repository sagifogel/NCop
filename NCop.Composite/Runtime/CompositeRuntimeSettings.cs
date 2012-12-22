using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Runtime;
using System.Reflection;

namespace NCop.Composite.Runtime
{
    public class CompositeRuntimeSettings : RuntimeSettings
    {
        public CompositeRuntimeSettings(IEnumerable<Assembly> assemblies = null)
            : base(assemblies) {
        }
    }
}
