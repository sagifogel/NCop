using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    public class AspectMap
    {
        public AspectMap(Type contractType, IEnumerable<Type> aspectTypes) {
            ContractType = contractType;
            AspectTypes = aspectTypes;
        }

        public Type ContractType { get; private set; }

        public IEnumerable<Type> AspectTypes { get; private set; }
    }
}
