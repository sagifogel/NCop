using NCop.Aspects.Aspects;
using NCop.Aspects.Aspects.Interception;

namespace NCop.Aspects.Framework
{
    public abstract class OnMethodBoundryConcern : IOnMethodBoundryContract
    {
        public abstract void OnInvoke(MethodExecution methodExecution);

        public abstract void Finally(MethodExecution methodExecution);

        public abstract void OnSuccess(MethodExecution methodExecution);

        public abstract void OnError(MethodExecution methodExecution);
    }
}
