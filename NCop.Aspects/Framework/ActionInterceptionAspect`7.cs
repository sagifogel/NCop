using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class ActionInterceptionAspect<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : IMethodInterceptionAspect
    {
        [OnMethodInvokeAdvice]
        public virtual void OnInvoke(ActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> args) {
            args.Proceed();
        }
    }
}
