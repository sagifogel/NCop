using NCop.Aspects.Engine;
using System;
using System.Collections.Concurrent;

namespace NCop.Aspects.Runtime
{
    public class AspectBuilderProvider : IAspectBuilderRepository, IAspectBuilderProvider
    {
        private ConcurrentDictionary<Type, IAspectBuilder> _builders = null;

        public AspectBuilderProvider() {
            _builders = new ConcurrentDictionary<Type, IAspectBuilder>();
        }

        public void AddBuilder(Type type, IAspectBuilder builder) {
            _builders.TryAdd(type, builder);
        }

        public IAspectBuilderCollection Builders {
            get {
                return new AspectBuilderCollection(_builders.Values);
            }
        }
    }
}
