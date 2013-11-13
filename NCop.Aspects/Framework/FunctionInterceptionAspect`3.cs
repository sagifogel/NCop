using NCop.Aspects.Advices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionAspect<TArg1, TArg2, TArg3, TResult>
    {
        [OnMethodInvokeAdvice]
        public abstract TResult OnInvoke(FunctionInterceptionArgs<TArg1, TArg2, TArg3, TResult> args);
    }
}
