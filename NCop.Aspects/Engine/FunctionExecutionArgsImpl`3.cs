using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionExecutionArgsImpl<TInstance, TArg1, TArg2, TArg3, TResult> : FunctionExecutionArgs<TArg1, TArg2, TArg3, TResult>, IFunctionArgs<TArg1, TArg2, TArg3, TResult>
    {
        public FunctionExecutionArgsImpl(TInstance instance, TArg1 arg1, TArg2 arg2, TArg3 arg3) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Instance = instance;
        }
    }
}

