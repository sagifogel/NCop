using System.Reflection.Emit;

namespace NCop.Weaving
{
    public interface IMethodEndWeaver
    {
        void Weave(ILGenerator ilGenerator);
    }
}
