using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    public class LocalBuilderRepository : ILocalBuilderRepository
    {
        private readonly Dictionary<Type, LocalBuilder> localBuilderMap = null;

        internal LocalBuilderRepository() {
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
