using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractAdviceArgs : IAdviceArgs
    {
        public object Instance { get; set; }
        public Exception Exception { get; set; }
    }
}
