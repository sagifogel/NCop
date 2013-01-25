using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    public class AspectMap
    {
        public AspectMap(Type contract, IEnumerable<Type> aspectTypes) {
            Contract = contract;
            AspectTypes = aspectTypes;
        }

        public Type Contract { get; private set; }

        public IEnumerable<Type> AspectTypes { get; private set; }
    }
}
