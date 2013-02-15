using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Framework
{
    public class GetPropertyInterceptionAspectAttribute : PropertyInterceptionAspectAttribute
    {
        [OnInvokeAdvice]
        public virtual void OnInvoke(GetPropertyInterception getPropertyInterception) { }
    }
}
