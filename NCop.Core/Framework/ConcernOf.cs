using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Framework
{
    public class ConcernOf<T> where T : class
    {
        public T Instance { get; private set; }
    }
}
