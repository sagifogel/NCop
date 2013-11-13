using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
    public class GenericFunctionExecutionArgs : IAdviceArgs, IFunctionExecutionArgs
    {
        public object Instance { get; protected set; }
        public MethodBase Method { get; protected set; }
        public object ReturnType { get; protected set; }
        public Arguments Arguments { get; protected set; }
        public Exception Exception { get; protected set; }
    }
}
