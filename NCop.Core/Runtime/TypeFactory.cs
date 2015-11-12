using System;
using System.Collections.Generic;

namespace NCop.Core.Runtime
{
    public class TypeFactory : ITypeFactory
    {
        private readonly IEnumerable<Type> types = null;

        public TypeFactory(IEnumerable<Type> types) {
            this.types = types;
        }

        public IEnumerable<Type> Types {
            get {
                return types;
            }
        }
    }
}
