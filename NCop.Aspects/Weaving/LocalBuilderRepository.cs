using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace NCop.Aspects.Weaving
{
    public class LocalBuilderRepository : ILocalBuilderRepository
    {
        private int id = 0;
        private static int count = 0;
        private readonly Dictionary<Type, LocalBuilder> localBuilderMap = null;

        internal LocalBuilderRepository() {
            id = Interlocked.Increment(ref count);
            localBuilderMap = new Dictionary<Type, LocalBuilder>();
        }

        public LocalBuilder Get(Type type) {
            return localBuilderMap[type];
        }

        public void Add(LocalBuilder localBuilder) {
            Add(localBuilder.LocalType, localBuilder);
        }

        public void Add(Type type, LocalBuilder localBuilder) {
            localBuilderMap.Add(type, localBuilder);
        }
    }
}
