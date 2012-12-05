using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Engine
{
    public class AspectMap
    {
        public AspectMap(Type contract, Type aspectType) {
            Contract = contract;
            AspectType = aspectType;
        }

        public Type Contract { get; set; }

        public Type AspectType { get; set; }
    }
}
