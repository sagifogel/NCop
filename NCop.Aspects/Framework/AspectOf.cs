using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public class AspectOf<T> : TypeLevelAspect where T : class
    {
        public T Instance { get; private set; }
    }
}
