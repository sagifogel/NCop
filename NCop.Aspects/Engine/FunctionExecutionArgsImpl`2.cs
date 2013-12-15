using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionExecutionArgsImpl<TInstance, TArg1, TArg2, TResult> : FunctionExecutionArgs<TArg1, TArg2, TResult>, IFunctionArgs<TArg1, TArg2, TResult>
    {
        public FunctionExecutionArgsImpl(TInstance instance, TArg1 arg1, TArg2 arg2) {
            Arg1 = arg1;
            Arg2 = arg2;
            Instance = instance;
        }
    }
}

