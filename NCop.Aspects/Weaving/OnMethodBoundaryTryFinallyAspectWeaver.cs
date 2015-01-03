using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class OnMethodBoundaryTryFinallyAspectWeaver : TryFinallyAspectWeaver
    {
        protected readonly IEnumerable<IMethodScopeWeaver> entryWeavers = null;

        public OnMethodBoundaryTryFinallyAspectWeaver(IEnumerable<IMethodScopeWeaver> entryWeavers, IEnumerable<IMethodScopeWeaver> tryWeavers, IEnumerable<IMethodScopeWeaver> finallyWeavers, IMethodScopeWeaver returnValueWeaver = null)
            : base(tryWeavers, finallyWeavers, returnValueWeaver) {
            this.entryWeavers = entryWeavers;
        }

        public override void Weave(ILGenerator ilGenerator) {
            weavers.AddRange(entryWeavers);
            base.Weave(ilGenerator);
        }
    }
}
