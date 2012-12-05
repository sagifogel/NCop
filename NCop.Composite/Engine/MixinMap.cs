using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Engine
{
    public class MixinMap
    {
        public MixinMap(Type contract, Type implementation) {
            Contract = contract;
            Implementation = implementation;
        }

        public Type Contract { get; set; }

        public Type Implementation { get; set; }
    }
}
