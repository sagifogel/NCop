using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionExecutionArgsImpl<TArg1, TArg2, TResult> : FunctionExecutionArgs<TArg1, TArg2, TResult>
    {
        public FunctionExecutionArgsImpl(object instance, TArg1 arg1, TArg2 arg2) {
            Arg1 = arg1;
            Arg2 = arg2;
            Instance = instance;
        }
    }
}

