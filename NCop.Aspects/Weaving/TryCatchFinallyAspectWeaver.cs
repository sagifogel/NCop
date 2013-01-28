using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class TryCatchFinallyAspectWeaver : TryFinallyAspectWeaver
    {
        protected readonly IMethodScopeWeaver catchWeaver = null;
        private readonly TryCatchFinallySettings tryCatchFinallySettings = null;

        internal TryCatchFinallyAspectWeaver(TryCatchFinallySettings tryCatchFinallySettings, IMethodScopeWeaver entryWeaver, IEnumerable<IMethodScopeWeaver> tryWeavers, IMethodScopeWeaver catchWeaver, IEnumerable<IMethodScopeWeaver> finallyWeavers, IMethodScopeWeaver returnValueWeaver = null)
            : base(entryWeaver, tryWeavers, finallyWeavers, returnValueWeaver) {
            this.catchWeaver = catchWeaver;
            this.tryCatchFinallySettings = tryCatchFinallySettings;
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var weavers = new List<IMethodScopeWeaver>();
            MethodScopeWeaversQueue methodScopeWeaversQueue = null;

            weavers.Add(entryWeaver);
            weavers.Add(new BeginExceptionBlockMethodScopeWeaver());
            weavers.AddRange(tryWeavers);
            weavers.Add(new BeginCatchBlockMethodScopeWeaver(tryCatchFinallySettings));
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

