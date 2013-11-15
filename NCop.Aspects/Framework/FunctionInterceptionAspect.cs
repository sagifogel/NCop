using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionAspect<TResult> : IMethodInterceptionAspect
    {
        [OnMethodInvokeAdvice]
        public virtual TResult OnInvoke(FunctionInterceptionArgs<TResult> args) {
            args.Proceed();

            return args.ReturnValue;
        }
    }
}
