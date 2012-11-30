using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Framework
{
    public class AspectOf<T> where T : class
    {
        public AspectOf(T instance) {
            Instance = instance;
        }

        public T Instance { get; private set; }
    }
}
