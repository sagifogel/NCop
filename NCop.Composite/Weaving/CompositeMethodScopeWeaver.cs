using System.Collections.Generic;
using System.Reflection.Emit;
using NCop.Core.Extensions;

namespace NCop.Core.Weaving
{
    public class CompositeMethodScopeWeaver : IMethodScopeWeaver
    {
        private ILGenerator _ilGenerator = null;
        private IEnumerable<IMethodScopeWeaver> _weavers = null;

        public CompositeMethodScopeWeaver(IEnumerable<IMethodScopeWeaver> weavers, ILGenerator ilGenerator) {
            _weavers = weavers;
            _ilGenerator = ilGenerator; 
        }

        public void Weave() {
            _weavers.ForEach(weaver => weaver.Weave());
        }
    }
}
