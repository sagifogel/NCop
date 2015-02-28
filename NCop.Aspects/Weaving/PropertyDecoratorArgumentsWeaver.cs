using NCop.Weaving.Extensions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class PropertyDecoratorArgumentsWeaver : IArgumentsWeaver
    {
        public void Weave(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);
        }
    }
}
