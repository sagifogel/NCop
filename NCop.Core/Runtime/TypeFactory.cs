using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
