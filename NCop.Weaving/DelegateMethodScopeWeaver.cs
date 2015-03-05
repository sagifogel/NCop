using System;
using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class DelegateMethodScopeWeaver : IMethodScopeWeaver
    {
        private readonly Action<ILGenerator> weaveAction = null;

        public DelegateMethodScopeWeaver(Action<ILGenerator> weaveAction) {
            this.weaveAction = weaveAction;
        }

        public void Weave(ILGenerator ilGenerator) {
            weaveAction(ilGenerator);
        }
    }
}
