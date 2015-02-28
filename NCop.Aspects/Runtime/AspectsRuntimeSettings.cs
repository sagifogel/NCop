using NCop.Core.Runtime;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Aspects.Runtime
{
    public class AspectsRuntimeSettings : RuntimeSettings
    {
        public AspectsRuntimeSettings(IEnumerable<Assembly> assemblies = null) : base(assemblies) { }
    }
}
