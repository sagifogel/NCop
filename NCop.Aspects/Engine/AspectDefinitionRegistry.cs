using NCop.Aspects.Aspects;
using NCop.Core.Lib;
using System.Collections.Concurrent;
using System.Reflection;

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
