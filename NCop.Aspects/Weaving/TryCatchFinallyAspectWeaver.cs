using NCop.Core.Extensions;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TryCatchFinallyAspectWeaver : OnMethodBoundaryTryFinallyAspectWeaver
    {
        protected readonly IEnumerable<IMethodScopeWeaver> catchWeavers = null;
        private readonly TryCatchFinallySettings tryCatchFinallySettings = null;

        internal TryCatchFinallyAspectWeaver(TryCatchFinallySettings tryCatchFinallySettings, IEnumerable<IMethodScopeWeaver> entryWeavers, IEnumerable<IMethodScopeWeaver> tryWeavers, IEnumerable<IMethodScopeWeaver> catchWeavers, IEnumerable<IMethodScopeWeaver> finallyWeavers, IMethodScopeWeaver returnValueWeaver = null)
            : base(entryWeavers, tryWeavers, finallyWeavers, returnValueWeaver) {
            this.catchWeavers = catchWeavers;
            this.tryCatchFinallySettings = tryCatchFinallySettings;
        }

        public override void Weave(ILGenerator ilGenerator) {
            var weavers = new List<IMethodScopeWeaver>();
            MethodScopeWeaversQueue methodScopeWeaversQueue = null;

            weavers.AddRange(entryWeavers);
            weavers.Add(new BeginExceptionBlockMethodScopeWeaver());
            weavers.Add(new BeginExceptionBlockMethodScopeWeaver());
            weavers.AddRange(tryWeavers);
            weavers.Add(new BeginCatchBlockMethodScopeWeaver(catchWeavers, tryCatchFinallySettings));
            weavers.Add(new EndExceptionBlockMethodScopeWeaver());
            weavers.Add(new FinallyMethodScopeWeaver(finallyWeavers));
            weavers.Add(new EndExceptionBlockMethodScopeWeaver());

            if (returnValueWeaver.IsNotNull()) {
                weavers.Add(returnValueWeaver);
            }

            methodScopeWeaversQueue = new MethodScopeWeaversQueue(weavers);
            methodScopeWeaversQueue.Weave(ilGenerator);
        }
    }
}

