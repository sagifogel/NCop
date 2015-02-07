using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;
using NCop.Core.Lib;

namespace NCop.Aspects.Engine
{
    internal class AspectDefinitionRegistry : Tuples<MethodInfo, IAspectDefinitionCollection>
    {
        private readonly ConcurrentDictionary<MethodInfo, IAspectDefinitionCollection> registry = null;

        public AspectDefinitionRegistry() {
            registry = new ConcurrentDictionary<MethodInfo, IAspectDefinitionCollection>();
        }
    }
}
