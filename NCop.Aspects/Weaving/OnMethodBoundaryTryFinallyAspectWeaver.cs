using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class OnMethodBoundaryTryFinallyAspectWeaver : TryFinallyAspectWeaver
    {
        protected readonly IMethodScopeWeaver entryWeaver = null;

        public OnMethodBoundaryTryFinallyAspectWeaver(IMethodScopeWeaver entryWeaver, IEnumerable<IMethodScopeWeaver> tryWeavers, IEnumerable<IMethodScopeWeaver> finallyWeavers, IMethodScopeWeaver returnValueWeaver = null)
            : base(tryWeavers, finallyWeavers, returnValueWeaver) {
            this.entryWeaver = entryWeaver;
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            weavers.Add(entryWeaver);
            
            return base.Weave(ilGenerator);
        }
    }
}
