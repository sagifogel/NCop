using NCop.Aspects.Engine;
using NCop.Core.Aspects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public class AspectBuilderRepository : IAspectBuilderRepository, IAspectBuilderProvider
    {
        protected ConcurrentDictionary<Type, IAspectBuilder> RegisteredBuilders = null;

        public AspectBuilderRepository() {
            RegisteredBuilders = new ConcurrentDictionary<Type, IAspectBuilder>();
        }

        public void AddBuilder(Type type, IAspectBuilder builder) {
            RegisteredBuilders.TryAdd(type, builder);
        }

        public IAspectBuilderCollection Builders {
            get {
                return new AspectBuilderCollection(RegisteredBuilders.Values);
            }
        }
    }
}
