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

        public TryCatchFinallyAspectWeaver(IMethodScopeWeaver entryWeaver, IEnumerable<IMethodScopeWeaver> tryWeavers, IMethodScopeWeaver catchWeaver, IEnumerable<IMethodScopeWeaver> finallyWeavers, IMethodScopeWeaver returnValueWeaver = null)
            : base(entryWeaver, tryWeavers, finallyWeavers, returnValueWeaver) {
            this.catchWeaver = catchWeaver;
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            MethodScopeWeaversQueue weaver = null;
            var weavers = new List<IMethodScopeWeaver>();
            
            weavers.Add(entryWeaver);
            weavers.AddRange(tryWeavers);
            weavers.Add(catchWeaver);
            weavers.AddRange(finallyWeavers);

            if (returnValueWeaver.IsNotNull()) {
                weavers.Add(returnValueWeaver);
            }

            weaver = new MethodScopeWeaversQueue(weavers);

            return weaver.Weave(ilGenerator);
        }
    }
}

