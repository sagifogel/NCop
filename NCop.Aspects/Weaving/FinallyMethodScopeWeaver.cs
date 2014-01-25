using NCop.Composite.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class FinallyMethodScopeWeaver : IMethodScopeWeaver
    {
        private readonly Label endOfExceptionBlockLabel;
        private readonly MethodScopeWeaversQueue finallyWeaversQueue = null;

        internal FinallyMethodScopeWeaver(IEnumerable<IMethodScopeWeaver> finallyWeavers, Label endOfExceptionBlockLabel) {
            this.endOfExceptionBlockLabel = endOfExceptionBlockLabel;
            finallyWeaversQueue = new MethodScopeWeaversQueue(finallyWeavers);
        }

        public ILGenerator Weave(ILGenerator ilGenerator) {
            ilGenerator.BeginFinallyBlock();
            finallyWeaversQueue.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Leave_S, endOfExceptionBlockLabel);

            return ilGenerator;
        }
    }
}