using NCop.Core.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    public class MethodScopeWeaversQueue : IMethodScopeWeaver
    {
        private readonly Queue<IMethodScopeWeaver> _queue = null;

        public MethodScopeWeaversQueue(IEnumerable<IMethodScopeWeaver> methodScopeWeavers) {
            _queue = new Queue<IMethodScopeWeaver>(methodScopeWeavers);
        }

        public ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            while (_queue.Count > 0) {
                _queue.Dequeue().Weave(iLGenerator, typeDefinition);
            }

            return iLGenerator;
        }
    }
}
