using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Framework
{
    public class GenericFunctionExecutionArgs : AbstractAdviceArgs, IFunctionExecutionArgs
    {
        public object ReturnType { get; protected set; }
        public Arguments Arguments { get; protected set; }
        public FlowBehavior FlowBehavior { get; protected set; }
    }
}
