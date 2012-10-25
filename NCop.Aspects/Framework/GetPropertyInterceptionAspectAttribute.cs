using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Interception;

namespace NCop.Aspects.Framework
{
    public class GetPropertyInterceptionAspectAttribute : PropertyInterceptionAspectAttribute
    {
        [OnInvokeAdvice]
        public virtual void OnInvoke(GetPropertyInterception getPropertyInterception) { }
    }
}
