using NCop.Aspects.Advices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionAspect<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>
    {
        [OnMethodInvokeAdvice]
        public abstract TResult OnInvoke(FunctionInterceptionArgs<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> args);
    }
}
