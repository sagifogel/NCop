using NCop.Weaving;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class EndExceptionBlockMethodScopeWeaver : IMethodScopeWeaver
    {
        internal EndExceptionBlockMethodScopeWeaver() {
        }

        public void Weave(ILGenerator ilGenerator) {
            ilGenerator.EndExceptionBlock();
        }
    }
}