using NCop.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Runtime
{
    public class AspectsRuntime : IRuntime
    {
        public AspectsRuntimeSettings Settings { get; set; }

        public void Run() {
        }
    }
}
