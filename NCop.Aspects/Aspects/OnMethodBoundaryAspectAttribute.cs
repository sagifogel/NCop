using NCop.Aspects.Advices;
using NCop.Aspects.Aspects.Interception;

namespace NCop.Aspects.Aspects
{
    public class OnMethodBoundaryAspectAttribute : MethodInterceptionAspectAttribute
    {
        [OnFinallyAdvice]
        public virtual void Finally(MethodInterception interception) { }

        [OnSuccessAdvice]
        public virtual void Success(MethodInterception interception) { }

        [OnErrorAdvice]
        public virtual void Error(MethodInterception interception) { }
    }
}
