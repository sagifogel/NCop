using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;

namespace NCop.Aspects.Runtime
{
    public class AspectsRuntimeSettings : AbstractRuntimeSettings
    {
        public AspectsRuntimeSettings(IEnumerable<Assembly> assemblies = null) : base(assemblies) { }

        public IAspectBuilderProvider AspectBuilderProvider { get; set; }
    }
}
