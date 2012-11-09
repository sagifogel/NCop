using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class MethodInterceptionConcernOf<TInstance> : MethodInterceptionConcern
    {
        public MethodInterceptionConcernOf(TInstance instance) {
            Instance = instance;
        }

        public TInstance Instance { get; private set; }
    }
}
