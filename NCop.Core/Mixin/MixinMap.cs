using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Mixin
{
    public class MixinMap
    {
        public MixinMap(Type contract, Type implementation) {
            Contract = contract;
            Implementation = implementation;
        }

        public Type Contract { get; private set; }

        public Type Implementation { get; private set; }
    }
}
