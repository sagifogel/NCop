using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class FunctionInterceptionAspect<TResult> : IMethodInterceptionAspect
    {
        [OnMethodInvokeAdvice]
        public virtual void OnInvoke(FunctionInterceptionArgs<TResult> args) {
            args.Proceed();
        }
    }
}
