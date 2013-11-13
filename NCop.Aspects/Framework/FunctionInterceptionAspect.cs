using NCop.Aspects.Advices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionAspect<TResult>
    {
        [OnMethodInvokeAdvice]
        public abstract TResult OnInvoke(FunctionInterceptionArgs<TResult> args);
    }
}
