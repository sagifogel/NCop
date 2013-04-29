using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Composite.Weaving
{
    internal class MethodScopeWeaversQueue : IMethodScopeWeaver
    {
        private readonly Queue<IMethodScopeWeaver> queue = null;

        internal MethodScopeWeaversQueue(IEnumerable<IMethodScopeWeaver> methodScopeWeavers) {
            queue = new Queue<IMethodScopeWeaver>(methodScopeWeavers);
        }

        public ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition) {
            while (queue.Count > 0) {
                queue.Dequeue().Weave(iLGenerator, typeDefinition);
            }

            return iLGenerator;
        }
    }
}
