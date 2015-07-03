using System.Reflection.Emit;

namespace NCop.Weaving
{
    public class MethodEndWeaver : IMethodEndWeaver
    {
        public void Weave(ILGenerator ilGenerator) {
            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
