using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Mixin
{
    public class MixinMap
    {
        public MixinMap(Type contractType, Type implementationType) {
            ContractType = contractType;
            ImplementationType = implementationType;
        }

        public Type ContractType { get; private set; }

        public Type ImplementationType { get; private set; }
    }
}
