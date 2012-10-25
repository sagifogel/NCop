using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects.Interception
{
    public class MethodExecution : IJointPoint
    {   
        public object Instance { get; private set; }

        public MethodInfo Method { get; private set; }

        public object[] Arguments { get; private set; }
    }
}
