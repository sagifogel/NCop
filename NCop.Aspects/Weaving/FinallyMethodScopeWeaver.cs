using NCop.Composite.Weaving;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class FinallyMethodScopeWeaver : IMethodScopeWeaver
    {
        private readonly MethodScopeWeaversQueue finallyWeaversQueue = null;

        internal FinallyMethodScopeWeaver(IEnumerable<IMethodScopeWeaver> finallyWeavers) {
            finallyWeaversQueue = new MethodScopeWeaversQueue(finallyWeavers);
        }

        public void Weave(ILGenerator ilGenerator) {
            ilGenerator.BeginFinallyBlock();
            finallyWeaversQueue.Weave(ilGenerator);
        }
    }
}