using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public class AspectBuilderRegistry
    {
        private static object _syncLock = new object();
        private ConcurrentDictionary<Type, IAspectBuilder> _registeredBuilders = null;

        public AspectBuilderRegistry() {
            _registeredBuilders = new ConcurrentDictionary<Type, IAspectBuilder>();
        }

        public void RegisterBuilder(Type type, IAspectBuilder builder) {
            _registeredBuilders.GetOrAdd(type, builder);
        }

        public IAspectBuilder GetBuilderByType(Type type) {
                
            IAspectBuilder builder;

            _registeredBuilders.TryGetValue(type, out builder);

            return builder;
        }

    }
}
