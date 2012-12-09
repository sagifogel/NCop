using NCop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Composite.Runtime
{
    public class CompositeRuntime
    {
        public CompositeRuntime() { }

        public CompositeRuntime(RuntimeSettings settings) {
            Settings = settings;
        }

        public RuntimeSettings Settings { get; set; }

        public override void Run() {
            throw new NotImplementedException();
        }
    }
}
