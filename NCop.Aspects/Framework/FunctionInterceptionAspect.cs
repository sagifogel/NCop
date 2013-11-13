using NCop.Aspects.Advices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionAspect<TInstance, TResult>
    {
        [OnMethodInvokeAdvice]
        public abstract TResult OnInvoke(FunctionInterceptionArgs<TInstance, TResult> args);
    }
}
