using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionAspect<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> : IMethodInterceptionAspect
    {
        [OnMethodInvokeAdvice]
        public virtual void OnInvoke(FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> args) {
            args.Proceed();
        }
    }
}
