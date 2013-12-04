using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class TryCatchFinallyAspectWeaver : TryFinallyAspectWeaver
    {
        protected readonly IEnumerable<IMethodScopeWeaver> catchWeavers = null;

        public TryCatchFinallyAspectWeaver(IEnumerable<IMethodScopeWeaver> entryWeavers, IEnumerable<IMethodScopeWeaver> tryWeavers, IEnumerable<IMethodScopeWeaver> catchWeavers, IEnumerable<IMethodScopeWeaver> finallyWeavers)
            : base(entryWeavers, tryWeavers, finallyWeavers) {
            this.catchWeavers = catchWeavers;
        }

        public override ILGenerator Weave(ILGenerator iLGenerator) {
            var weavers = entryWeavers.Concat(tryWeavers).Concat(catchWeavers).Concat(finallyWeavers);
            var weaver = new MethodScopeWeaversQueue(weavers);

            return weaver.Weave(iLGenerator);
        }
    }
}

