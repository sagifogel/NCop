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
            MethodScopeWeaversQueue methodScopeWeaversQueue = null;
            var weavers = new List<IMethodScopeWeaver>() { entryWeaver };
            
            weavers.Add(entryWeaver);
            weavers.AddRange(tryWeavers);
            weavers.AddRange(finallyWeavers);
            
            if (returnValueWeaver.IsNotNull()) {
                weavers.Add(returnValueWeaver);
            }

            methodScopeWeaversQueue = new MethodScopeWeaversQueue(weavers);

            return methodScopeWeaversQueue.Weave(ilGenerator);
        }
    }
}
