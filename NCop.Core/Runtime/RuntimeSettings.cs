using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Core.Runtime
{
    public class RuntimeSettings : IRuntimeSettings
    {
        public IEnumerable<Type> Types { get; set; }
        public IEnumerable<Assembly> Assemblies { get; set; }
    }
}
