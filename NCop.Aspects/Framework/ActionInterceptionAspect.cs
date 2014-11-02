using NCop.Aspects.Advices;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public abstract class ActionInterceptionAspect : IMethodInterceptionAspect
    {
        [OnMethodInvokeAdvice]
        public virtual void OnInvoke(ActionInterceptionArgs args) {
            args.Proceed();
        }
    }
}
