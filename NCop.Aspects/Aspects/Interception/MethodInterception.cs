using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Aspects.Interception
{
    public class MethodInterception : IJointPoint
    {   
        public object Proceed() {
            return null;
        }

        public object Instance { get; private set; }

        public bool IsPrevented { get; private set; }

        public MethodInfo Method { get; private set; }

        public object[] Arguments { get; private set; }
    }
}
