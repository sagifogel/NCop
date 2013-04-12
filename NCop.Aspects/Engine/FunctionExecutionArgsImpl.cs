using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionExecutionArgsImpl<TInstance, TResult> : FunctionExecutionArgs<TResult>, IFunctionArgs<TResult>
    {
        public FunctionExecutionArgsImpl(TInstance instance, MethodInfo method) {
            Method = method;
            Instance = instance;
        }
    }
}
