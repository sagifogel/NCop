using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal class TryFinallyAspectWeaver : IMethodScopeWeaver
    {
        protected readonly IEnumerable<IMethodScopeWeaver> tryWeavers = null;
        protected readonly IEnumerable<IMethodScopeWeaver> entryWeavers = null;
        protected readonly IEnumerable<IMethodScopeWeaver> finallyWeavers = null;

        public TryFinallyAspectWeaver(IEnumerable<IMethodScopeWeaver> entryWeavers, IEnumerable<IMethodScopeWeaver> tryWeavers, IEnumerable<IMethodScopeWeaver> finallyWeavers) {
            this.tryWeavers = tryWeavers;
            this.entryWeavers = entryWeavers;
            this.finallyWeavers = finallyWeavers;
        }

        public virtual ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            var weavers = entryWeavers.Concat(tryWeavers).Concat(finallyWeavers);
            var weaver = new MethodScopeWeaversQueue(weavers);
            
            return weaver.Weave(iLGenerator, typeDefinition);
        }
    }
}
