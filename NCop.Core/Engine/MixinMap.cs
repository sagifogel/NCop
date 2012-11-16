using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Engine
{
    public class MixinMap
    {
        private Tuple<Type, Type> _mixinMap = null;

        public MixinMap(Type contract, Type implementation) {
            _mixinMap = Tuple.Create(contract, implementation);
        }

        public Type Contract {
            get {
              return _mixinMap.Item1;
            }
        }

        public Type Implementation {
            get {
                return _mixinMap.Item2;
            }
        }
    }
}
