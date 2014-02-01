using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class ActionExecutionArgsImpl<TInstance> : ActionExecutionArgs, IActionArgs
    {
        public ActionExecutionArgsImpl(TInstance instance, MethodInfo method) {
            Method = method;
            Instance = instance;
        }
    }
}
