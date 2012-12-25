using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects
{
    public class AspectMap
    {
        public AspectMap(Type contract, Type aspectType) {
            Contract = contract;
            AspectType = aspectType;
        }

        public Type Contract { get; private set; }

        public Type AspectType { get; private set; }
    }
}
