using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Framework
{
    public class GetPropertyInterceptionAspectAttribute : PropertyInterceptionAspectAttribute
    {
        [OnMethodInvokeAdvice]
        public virtual void OnInvoke(GetPropertyInterception getPropertyInterception) { }
    }
}
