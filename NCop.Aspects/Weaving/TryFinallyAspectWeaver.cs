using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TryFinallyAspectWeaver : IMethodScopeWeaver
    {
        protected readonly IMethodScopeWeaver entryWeaver = null;
        protected readonly IMethodScopeWeaver returnValueWeaver = null;
        protected readonly IEnumerable<IMethodScopeWeaver> tryWeavers = null;
        protected readonly IEnumerable<IMethodScopeWeaver> finallyWeavers = null;

        public TryFinallyAspectWeaver(IMethodScopeWeaver entryWeaver, IEnumerable<IMethodScopeWeaver> tryWeavers, IEnumerable<IMethodScopeWeaver> finallyWeavers, IMethodScopeWeaver returnValueWeaver = null) {
            this.tryWeavers = tryWeavers;
            this.entryWeaver = entryWeaver;
            this.finallyWeavers = finallyWeavers;
            this.returnValueWeaver = returnValueWeaver;
        }

        public virtual ILGenerator Weave(ILGenerator ilGenerator) {
            var weavers = new List<IMethodScopeWeaver>();
            MethodScopeWeaversQueue methodScopeWeaversQueue = null;
            var endOfExceptionBlockLabel = ilGenerator.DefineLabel();

            weavers.Add(entryWeaver);
            weavers.Add(new BeginExceptionBlockMethodScopeWeaver());
            weavers.AddRange(tryWeavers);
            weavers.Add(new FinallyMethodScopeWeaver(finallyWeavers, endOfExceptionBlockLabel));
            weavers.Add(new EndExceptionBlockMethodScopeWeaver(endOfExceptionBlockLabel));

            if (returnValueWeaver.IsNotNull()) {
                weavers.Add(returnValueWeaver);
            }

            methodScopeWeaversQueue = new MethodScopeWeaversQueue(weavers);

            return methodScopeWeaversQueue.Weave(ilGenerator);
        }
    }
}
