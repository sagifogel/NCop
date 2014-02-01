using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class ActionExecutionArgsImpl<TInstance, TArg1> : ActionExecutionArgs<TArg1>, IActionArgs<TArg1>
    {
        public ActionExecutionArgsImpl(TInstance instance, MethodInfo method, TArg1 arg1) {
            Arg1 = arg1;
            Method = method;
            Instance = instance;
        }
    }
}
