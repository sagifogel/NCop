using NCop.Aspects.Aspects.Interception;

namespace NCop.Aspects.Aspects
{
    public class OnMethodBoundaryAspectAttribute : MethodInterceptionAspectAttribute
    {
        public virtual void Finally(MethodInterception interception) { }

        public virtual void Success(MethodInterception interception) { }

        public virtual void Error(MethodInterception interception) { }
    }
}
