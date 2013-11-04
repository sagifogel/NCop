using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public class GenericFunctionExecutionArgs : MethodExecutionArgs, IFunctionExecutionArgs
    {
        public object ReturnType { get; protected set; }
        public Arguments Arguments { get; protected set; }
    }
}
