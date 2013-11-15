using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionAspect<TArg1, TResult> : IMethodInterceptionAspect
    {
        [OnMethodInvokeAdvice]
        public virtual TResult OnInvoke(FunctionInterceptionArgs<TArg1, TResult> args) {
            args.Proceed();

            return args.ReturnValue;
        }
    }
}
