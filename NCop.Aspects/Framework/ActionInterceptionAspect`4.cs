using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Framework
{
    public abstract class ActionInterceptionAspect<TArg1, TArg2, TArg3, TArg4> : IMethodInterceptionAspect
    {
        [OnMethodInvokeAdvice]
        public virtual void OnInvoke(ActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4> args) {
            args.Proceed();
        }
    }
}
