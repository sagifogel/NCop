using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TryFinallyAspectWeaver : IMethodScopeWeaver
    {
        protected readonly List<IMethodScopeWeaver> weavers = null;
        protected readonly IMethodScopeWeaver returnValueWeaver = null;
        protected readonly IEnumerable<IMethodScopeWeaver> tryWeavers = null;
        protected readonly IEnumerable<IMethodScopeWeaver> finallyWeavers = null;

        public TryFinallyAspectWeaver(IEnumerable<IMethodScopeWeaver> tryWeavers, IEnumerable<IMethodScopeWeaver> finallyWeavers, IMethodScopeWeaver returnValueWeaver = null) {
            this.tryWeavers = tryWeavers;
            this.finallyWeavers = finallyWeavers;
            weavers = new List<IMethodScopeWeaver>();
            this.returnValueWeaver = returnValueWeaver;
        }

        public virtual ILGenerator Weave(ILGenerator ilGenerator) {
            MethodScopeWeaversQueue methodScopeWeaversQueue = null;

            weavers.Add(new BeginExceptionBlockMethodScopeWeaver());
            weavers.AddRange(tryWeavers);
            weavers.Add(new FinallyMethodScopeWeaver(finallyWeavers));
            weavers.Add(new EndExceptionBlockMethodScopeWeaver());

            if (returnValueWeaver.IsNotNull()) {
                weavers.Add(returnValueWeaver);
            }

            methodScopeWeaversQueue = new MethodScopeWeaversQueue(weavers);

            return methodScopeWeaversQueue.Weave(ilGenerator);
        }
    }
}
