using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public abstract class AdviceArgs : IAdviceArgs
    {
        public object Instance { get; set; }
        public MethodBase Method { get; set; }
        public Exception Exception { get; set; }
    }
}
