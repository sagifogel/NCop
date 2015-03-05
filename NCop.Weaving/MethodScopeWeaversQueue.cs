using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class MethodScopeWeaversQueue : IMethodScopeWeaver
    {
        private readonly Queue<IMethodScopeWeaver> queue = null;

        public MethodScopeWeaversQueue(IEnumerable<IMethodScopeWeaver> methodScopeWeavers) {
            queue = new Queue<IMethodScopeWeaver>(methodScopeWeavers);
        }

        public void Weave(ILGenerator ilGenerator) {
            while (queue.Count > 0) {
                queue.Dequeue().Weave(ilGenerator);
            }
        }
    }
}
