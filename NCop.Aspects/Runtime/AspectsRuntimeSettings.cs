﻿using NCop.Core;
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
        public IAspectBuilderProvider AspectBuilderProvider { get; set; }
    }
}
