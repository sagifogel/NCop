using NCop.Core;
using NCop.Core.Extensions;
using NCop.Core.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;

namespace NCop.Aspects.Runtime
{
    public class AspectsRuntimeSettings : RuntimeSettings
    {
        public AspectsRuntimeSettings(IEnumerable<Assembly> assemblies = null) : base(assemblies) { }
    }
}
