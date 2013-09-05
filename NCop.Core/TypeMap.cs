using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core
{
    public class TypeMap
    {
        public TypeMap(Type contractType, Type implementationType) {
            ContractType = contractType;
            ImplementationType = implementationType;
        }

        public Type ContractType { get; private set; }
        public Type ImplementationType { get; private set; }
    }
}
