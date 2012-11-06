using NCop.Aspects.Engine;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public class AbstractBuilderRegistry : IAspectBuilderRegistry, IAspectBuilderProvider
    {
        protected ConcurrentDictionary<Type, IAspectBuilder> RegisteredBuilders = null;

        public AbstractBuilderRegistry() {
            RegisteredBuilders = new ConcurrentDictionary<Type, IAspectBuilder>();
        }

        public void RegisterBuilder(Type type, IAspectBuilder builder) {
            RegisteredBuilders.TryAdd(type, builder);
        }

        public IAspectBuilderCollection Builders {
            get {
                return new AspectBuilderCollection(RegisteredBuilders.Values);
            }
        }
    }
}
